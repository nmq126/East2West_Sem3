using East2West.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using East2West.Models;
using Microsoft.AspNet.Identity;

namespace East2West.Controllers
{
    public class ClientTourController : Controller
    {
        private DBContext db = new DBContext();

        public class TourDetail
        {
            public double price { get; set; }
            public int seat { get; set; }

            public DateTime startDate { get; set; }
        }

        public ActionResult GetListTour()
        {
            var tour = db.Tours.Include(o => o.TourDetails).OrderByDescending(o => o.CreatedAt);
            return View(tour.ToList());
        }

        public ActionResult Details(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Include(t => t.TourSchedules).Include(t => t.TourDetails).FirstOrDefault(t => t.Id == id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourDetailPrice = tour.TourDetails.First().Price * (1 - Convert.ToDouble(tour.TourDetails.First().Discount) / 100);
            ViewBag.TourDetailSeat = tour.TourDetails.First().AvailableSeat;
            ViewBag.TourDetailDate = tour.TourDetails.First().DepartureDay.ToString("dd-MM-yyyy");
            ViewBag.TourDetailId = tour.TourDetails.First().Id;
            return View(tour);
        }

        public JsonResult GetDetails(string id, string tourDetailId)
        {
            var tourDetailReplace = new TourDetail();
            Tour tour = db.Tours.Include(t => t.TourSchedules).Include(t => t.TourDetails).FirstOrDefault(t => t.Id == id);
            foreach (var tourDetail in tour.TourDetails)
            {
                if (tourDetail.Id == tourDetailId)
                {
                    tourDetailReplace.price = tourDetail.Price * (1 - Convert.ToDouble(tourDetail.Discount) / 100);
                    tourDetailReplace.seat = tourDetail.AvailableSeat;
                    tourDetailReplace.startDate = tourDetail.DepartureDay;
                }
            }

            return Json(new
            {
                price = tourDetailReplace.price,
                seat = tourDetailReplace.seat,
                startDay = tourDetailReplace.startDate
            }, JsonRequestBehavior.AllowGet);
        }
    }
}