﻿using East2West.Data;
using East2West.Models;
using Microsoft.AspNet.Identity;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class OrderTourController : Controller
    {
        private DBContext db = new DBContext();

        [HttpPost]
        public JsonResult CreateTourOrder(string tourDetailId, double unitPrice, int quantity)
        {
            if (User.Identity.IsAuthenticated)
            {
                string userId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var order = new Models.Order()
                {
                    Id = String.Concat("ORD_", Guid.NewGuid().ToString("N").Substring(0, 5)),
                    UserId = userId,
                    TotalPrice = unitPrice * quantity,
                    Type = 1,
                    Status = -1,
                    CreatedAt = DateTime.Now
                };
                db.Orders.Add(order);
                var OrderTours = new OrderTour()
                {
                    OrderId = order.Id,
                    TourDetailId = tourDetailId,
                    UnitPrice = unitPrice,
                    Quantity = quantity
                };
                db.OrderTours.Add(OrderTours);
                db.SaveChanges();
                return Json(new
                {
                    message = "Order success.",
                    status = 1
                });
            }
            else
            {
                var tourDetail = db.TourDetails.Find(tourDetailId);
                var tourId = tourDetail.TourId;
                Session["currentUrl"] = "/home/tours/" + tourId;
                return Json(new
                {
                    message = "You must login to order.",
                    status = -1
                });
            }
        }

        private Payment payment;

        //Create Payment
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string name, double? price, int? quantity)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            listItems.items.Add(new Item()
            {
                name = name,
                currency = "USD",
                price = Convert.ToString(price),
                quantity = Convert.ToString(quantity),
                sku = "sku"
            });

            var payer = new Payer() { payment_method = "paypal" };

            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&Cancel=true",
                return_url = redirectUrl
            };

            var details = new Details()
            {
                tax = "0",
                shipping = "0",
                subtotal = Convert.ToString(price * quantity)
            };

            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) + Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction()
            {
                description = "East2West transaction description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount,
                item_list = listItems
            });

            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };

            return payment.Create(apiContext);
        }

        //Excute Payment
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };
            this.payment = new Payment() { id = paymentId };
            return this.payment.Execute(apiContext, paymentExecution);
        }

        public ActionResult PaymentWithPaypal(string id, string name, double? price, int? quantity, string idTourDetail)
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/OrderTour/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, name, price, quantity);
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    Session["idOrder"] = id;
                    Session["tourDetailId"] = idTourDetail;
                    Session["seat"] = quantity;
                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypalRedirectUrl = link.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypalRedirectUrl);
                }
                else
                {
                    var guid = Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("~/Views/Home/Page_404.cshtml");
                    }
                }
            }
            catch (Exception e)
            {
                PaypalLogger.Log("Error: " + e.Message);
                return View("~/Views/Home/Page_404.cshtml");
            }
            var idOrder = Session["idOrder"].ToString();
            var idTourDetailToChange = Session["tourDetailId"].ToString();
            var seat = Convert.ToInt32(Session["seat"]);
            var order = db.Orders.Where(o => o.Id.Equals(idOrder)).FirstOrDefault();
            var tourDetail = db.TourDetails.Where(t => t.Id.Equals(idTourDetailToChange)).FirstOrDefault();
            if (order != null)
            {
                order.Status = 1;
                order.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            if (tourDetail != null)
            {
                tourDetail.AvailableSeat -= seat;
                db.SaveChanges();
            }
            Session.Remove("idOrder");
            Session.Remove("tourDetailId");
            Session.Remove("seat");
            return RedirectToAction("ThankYou", "Home");
        }

        public JsonResult CancelPayment(string id)
        {
            if (id == null)
            {
                return Json(new
                {
                    message = "Something went wrong. Please try again.",
                    status = -1
                });
            }
            var order = db.Orders.FirstOrDefault(c => c.Id == id);
            if (order == null)
            {
                return Json(new
                {
                    message = "Cant find your order. Please try again.",
                    status = -2
                });
            }
            order.Status = 0;
            order.UpdatedAt = DateTime.Now;
            db.SaveChanges();
            return Json(new
            {
                message = "Cancel Success.",
                status = 1
            });
        }

        public JsonResult RefundPayment(string id)
        {
            if (id == null)
            {
                return Json(new
                {
                    message = "Something went wrong. Please try again.",
                    status = -1
                });
            }
            var order = db.Orders.Include(o => o.OrderCars).Include(o => o.OrderTours).FirstOrDefault(c => c.Id == id);
            if (order == null)
            {
                return Json(new
                {
                    message = "Cant find your order. Please try again.",
                    status = -2
                });
            }
            var presentTime = DateTime.Now;
            TimeSpan span = presentTime.Subtract((DateTime)order.UpdatedAt);
            int percent;
            switch (span.Days)
            {
                case 1:
                    percent = 75;
                    break;

                case 2:
                    percent = 80;
                    break;

                case 3:
                    percent = 85;
                    break;

                case 4:
                    percent = 90;
                    break;

                case 5:
                    percent = 95;
                    break;

                default:
                    percent = 95;
                    break;
            }
            var refund = new Models.Refund()
            {
                Id = String.Concat("REF_", Guid.NewGuid().ToString("N").Substring(0, 5)),
                Percent = percent,
                Status = 0,
                TotalPrice = order.TotalPrice * (Convert.ToDouble(percent) / 100),
                CreatedAt = DateTime.Now
            };
            order.Refund = refund;
            order.Status = -2;
            order.UpdatedAt = DateTime.Now;
            if (order.Type == 1)
            {
                order.OrderTours.First().TourDetail.AvailableSeat += order.OrderTours.First().Quantity;
            }
            else
            {
                order.OrderCars.First().CarSchedule.Status = -1;
            }
            db.Refunds.Add(refund);
            db.SaveChanges();
            return Json(new
            {
                message = "Your refund is now pending.",
                status = 1
            });
        }
    }
}