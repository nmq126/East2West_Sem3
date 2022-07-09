using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using East2West.Data;
using East2West.Models;
using PagedList;

namespace East2West.Controllers
{
    public class RefundsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Refunds
        public ActionResult Index(int? page, int? status, int? typeId, string userId, string orderId, string id
            , string startCreatedDay, string endCreatedDay, int? percentId, string sortType)
        {
            ViewBag.BreadCrumb = "Refund list";

            var refunds = db.Refunds.Include(r => r.Order);

            ViewBag.Status = status;
            ViewBag.Id = id;
            ViewBag.OrderId = orderId;
            ViewBag.UserId = userId;
            ViewBag.TypeId = typeId;
            ViewBag.PercentId = percentId;
            ViewBag.StartCreatedDay = startCreatedDay;
            ViewBag.EndCreatedDay = endCreatedDay;

            if (!String.IsNullOrEmpty(id))
            {
                refunds = refunds.Where(o => o.Id.Contains(id));
            }

            if (!String.IsNullOrEmpty(orderId))
            {
                refunds = refunds.Where(o => o.Order.Id == orderId);
            }

            if (!String.IsNullOrEmpty(userId))
            {
                refunds = refunds.Where(o => o.Order.UserId.Contains(userId));
            }

            switch (typeId)
            {
                case 1:
                    refunds = refunds.Where(o => o.Order.Type == 1);
                    break;
                case 2:
                    refunds = refunds.Where(o => o.Order.Type == 2);
                    break;
                case 0:
                default:
                    break;
            }
            switch (percentId)
            {
                case 75:
                    refunds = refunds.Where(o => o.Percent == 75);
                    break;
                case 80:
                    refunds = refunds.Where(o => o.Percent == 80);
                    break;
                case 85:
                    refunds = refunds.Where(o => o.Percent == 85);
                    break;
                case 90:
                    refunds = refunds.Where(o => o.Percent == 90);
                    break;
                case 95:
                    refunds = refunds.Where(o => o.Percent == 95);
                    break;
                case 0:
                default:
                    break;
            }
            switch (status)
            {
                case 0:
                    refunds = refunds.Where(r => r.Status == 0);
                    break;
                case 1:
                    refunds = refunds.Where(r => r.Status == 1);
                    break;
                case 2:
                default:
                    break;
            }
            if (!String.IsNullOrEmpty(startCreatedDay) && !String.IsNullOrEmpty(endCreatedDay))
            {
                var start = DateTime.Parse(startCreatedDay);
                var end = DateTime.Parse(endCreatedDay);
                refunds = refunds.Where(o => o.CreatedAt >= start && o.CreatedAt <= end);
            }
            switch (sortType)
            {
                case "createdAt_asc":
                    refunds = refunds.OrderBy(r => r.CreatedAt);
                    break;
                case "price_asc":
                    refunds = refunds.OrderBy(r => r.TotalPrice);
                    break;
                case "price_desc":
                    refunds = refunds.OrderByDescending(r => r.TotalPrice);
                    break;
                case "createdAt_desc":
                default:
                    refunds = refunds.OrderByDescending(r => r.CreatedAt);
                    break;
            }
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(refunds.ToPagedList(pageNumber, pageSize));
        }

        // GET: Refunds/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Refund refund = db.Refunds.Find(id);
            if (refund == null)
            {
                return HttpNotFound();
            }
            return View(refund);
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
