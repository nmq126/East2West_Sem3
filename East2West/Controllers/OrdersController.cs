using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using East2West.Data;
using East2West.Models;
using PagedList;

namespace East2West.Controllers
{
    public class OrdersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Orders
        public ActionResult GetTour(int? page, string departureId, string destinationId, string sortType, int? status, string unit_price_range,
            string ticket_number, string duration_range, string orderId, string username, string startDepartureDay, string endDepartureDay
            , string startCreatedDay, string endCreatedDay)
        {
            ViewBag.BreadCrumb = "Tour analysis";

            var orders = db.Orders.Where(o => o.Type == 1)
                .Include(o => o.OrderTours)
                .Include(o => o.Refund)
                .Include(o => o.User);

            ViewBag.Status = status;
            ViewBag.Username = username;
            ViewBag.OrderId = orderId;
            ViewBag.SortType = sortType;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            ViewBag.UnitPriceRange = unit_price_range;
            ViewBag.TicketNumber = ticket_number;
            ViewBag.DurationRange = duration_range;
            ViewBag.StartDepartureDay = startDepartureDay;
            ViewBag.EndDepartureDay = endDepartureDay;
            ViewBag.StartCreatedDay = startCreatedDay;
            ViewBag.EndCreatedDay = endCreatedDay;
            ViewBag.LocationList = from l in db.Locations select l;

            if (!String.IsNullOrEmpty(orderId))
            {
                orders = orders.Where(o => o.Id.Contains(orderId));
            }

            if (!String.IsNullOrEmpty(username))
            {
                orders = orders.Where(o => o.User.UserName.Contains(username));
            }

            if (!String.IsNullOrEmpty(departureId))
            {
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.DepartureId == departureId);
            }

            if (!String.IsNullOrEmpty(destinationId))
            {
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.DestinationId == destinationId);
            }
            if (!String.IsNullOrEmpty(startDepartureDay) && !String.IsNullOrEmpty(endDepartureDay))
            {
                var start = DateTime.Parse(startDepartureDay);
                var end = DateTime.Parse(endDepartureDay);
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.DepartureDay >=  start
                                        && o.OrderTours.FirstOrDefault().TourDetail.DepartureDay <= end);
            }
            if (!String.IsNullOrEmpty(startCreatedDay) && !String.IsNullOrEmpty(endCreatedDay))
            {
                var start = DateTime.Parse(startCreatedDay);
                var end = DateTime.Parse(endCreatedDay);
                orders = orders.Where(o => o.CreatedAt >= start && o.CreatedAt <= end);
            }
            switch (status)
            {
                case 3:
                    break;
                case 2:
                    orders = orders.Where(t => t.Status == 2);
                    break;
                case 1:
                    orders = orders.Where(t => t.Status == 1);
                    break;
                case 0:
                    orders = orders.Where(t => t.Status == 0);
                    break;
                case -1:
                    orders = orders.Where(t => t.Status == -1);
                    break;
                case -2:
                    orders = orders.Where(t => t.Status == -2);
                    break;
                default:
                    break;
            }

            switch (duration_range)
            {
                case "all":
                    break;
                case "lte3":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 3);
                    break;
                case "4to7":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration >= 4 && o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 7);
                    break;
                case "gt7":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration > 7);
                    break;
                default:
                    break;
            }

            switch (ticket_number)
            {
                case "all":
                    break;
                case "lte2":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().Quantity <= 2);
                    break;
                case "2to5":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().Quantity > 2 && o.OrderTours.FirstOrDefault().Quantity <= 5);
                    break;
                case "gt5":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().Quantity > 5);
                    break;
                default:
                    break;
            }

            switch (sortType)
            {
                case "createdAt_asc":
                    orders = orders.OrderBy(s => s.CreatedAt);
                    break;
                case "createdAt_desc":
                    orders = orders.OrderByDescending(s => s.CreatedAt);
                    break;
                case "departureAt_asc":
                    orders = orders.OrderBy(o => o.OrderTours.FirstOrDefault().TourDetail.DepartureDay);
                    break;
                case "departureAt_desc":
                    orders = orders.OrderByDescending(o => o.OrderTours.FirstOrDefault().TourDetail.DepartureDay);
                    break;
                case "totalPrice_asc":
                    orders = orders.OrderBy(t => t.TotalPrice);
                    break;
                case "totalPrice_desc":
                    orders = orders.OrderBy(t => t.TotalPrice);
                    break;
                default:
                    orders = orders.OrderByDescending(s => s.CreatedAt);
                    break;
            }
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            double revenue = 0;
            foreach (var item in orders.Where(o => o.Status == 1))
            {
                revenue += item.TotalPrice;
            }
            ViewBag.TotalRevenue = revenue;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Refunds, "Id", "Id");
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserId,RefundId,TotalPrice,Type,Status,CreatedAt,UpdatedAt,DeletedAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Refunds, "Id", "Id", order.Id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Refunds, "Id", "Id", order.Id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserId,RefundId,TotalPrice,Type,Status,CreatedAt,UpdatedAt,DeletedAt")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Refunds, "Id", "Id", order.Id);
            ViewBag.UserId = new SelectList(db.Users, "Id", "FirstName", order.UserId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
