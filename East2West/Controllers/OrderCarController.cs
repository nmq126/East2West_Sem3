using East2West.Data;
using East2West.Models;
using Microsoft.AspNet.Identity;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class OrderCarController : Controller
    {
        private DBContext db = new DBContext();

        [HttpPost]
        public JsonResult CreateCarOrder(string carId, string startDay, string endDay, double pricePerDay)
        {
            if (User.Identity.IsAuthenticated)
            {
                var car = db.Cars.Include(c => c.CarSchedules).Where(c => c.Id == carId).FirstOrDefault();

                TimeSpan span = Convert.ToDateTime(endDay).Subtract(Convert.ToDateTime(startDay));
                //Create car schedule
                var carSchedule = new CarSchedule()
                {
                    Id = String.Concat("CARSCH_", Guid.NewGuid().ToString("N").Substring(0, 5)),
                    CarId = carId,
                    StartDay = Convert.ToDateTime(startDay),
                    EndDay = Convert.ToDateTime(endDay),
                    Status = 0,
                    CreatedAt = DateTime.Now
                };
                var thisCarSchedule = car.CarSchedules;
                foreach (var item in thisCarSchedule)
                {
                    if (carSchedule.StartDay <= item.EndDay && carSchedule.EndDay >= item.StartDay)
                    {
                        return Json(new
                        {
                            message = "This car is busy from " + item.StartDay.ToShortDateString() + " to " + item.EndDay.ToShortDateString(),
                            status = 0
                        });
                    }
                }
                db.CarSchedules.Add(carSchedule);
                db.SaveChanges();
                //Create order
                string userId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
                var order = new Models.Order()
                {
                    Id = String.Concat("ORD_", Guid.NewGuid().ToString("N").Substring(0, 5)),
                    UserId = userId,
                    TotalPrice = span.Days * pricePerDay,
                    Type = 2,
                    Status = -1,
                    CreatedAt = DateTime.Now,
                };
                db.Orders.Add(order);
                db.SaveChanges();
                //Create order car
                var orderCar = new OrderCar()
                {
                    OrderId = order.Id,
                    CarScheduleId = carSchedule.Id,
                    UnitPrice = order.TotalPrice
                };
                db.OrderCars.Add(orderCar);
                db.SaveChanges();
                return Json(new
                {
                    message = "Order success.",
                    status = 1
                });
            }
            else
            {
                return Json(new
                {
                    message = "You must login to order.",
                    status = -1
                });
            }
        }

        private Payment payment;

        //Create Payment
        private Payment CreatePayment(APIContext apiContext, string redirectUrl, string name, double? pricePerDay, int? rentDay)
        {
            var listItems = new ItemList() { items = new List<Item>() };
            listItems.items.Add(new Item()
            {
                name = name,
                currency = "USD",
                price = Convert.ToString(pricePerDay),
                quantity = Convert.ToString(rentDay),
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
                subtotal = Convert.ToString(pricePerDay * rentDay)
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

        public ActionResult PaymentWithPaypal(string id, string name, double? pricePerDay, int? rentDay, string idCarSchedule)
        {
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/OrderCar/PaymentWithPaypal?";
                    var guid = Convert.ToString((new Random()).Next(100000));
                    var createdPayment = this.CreatePayment(apiContext, baseURI + "guid=" + guid, name, pricePerDay, rentDay);
                    var links = createdPayment.links.GetEnumerator();
                    string paypalRedirectUrl = string.Empty;
                    Session["idOrder"] = id;
                    Session["idCarSchedule"] = idCarSchedule;

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
            var idCarScheduleToChange = Session["idCarSchedule"].ToString();
            var order = db.Orders.Where(o => o.Id.Equals(idOrder)).FirstOrDefault();
            var carSchedule = db.CarSchedules.Where(t => t.Id.Equals(idCarScheduleToChange)).FirstOrDefault();
            if (order != null)
            {
                order.Status = 1;
                order.UpdatedAt = DateTime.Now;
                db.SaveChanges();
            }
            if (carSchedule != null)
            {
                carSchedule.Status = 1;
                db.SaveChanges();
            }
            Session.Remove("idOrder");
            Session.Remove("idCarSchedule");

            return RedirectToAction("ThankYou", "Home");
        }
    }
}