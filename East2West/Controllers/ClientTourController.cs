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
using PagedList;

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

        public ActionResult GetListTour(string sortType, string keyword, string price_range, string duration_range, string departureId, string destinationId, string categoryId, string rating, int? page)
        {
            var tours = from t in db.Tours select t;
            ViewBag.CategoryList = from c in db.TourCategories select c;
            ViewBag.LocationList = from l in db.Locations select l;

            ViewBag.Keyword = keyword;
            ViewBag.SortType = sortType;
            ViewBag.PriceRange = price_range;
            ViewBag.Rating = rating;
            ViewBag.DurationRange = duration_range;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            ViewBag.CategoryId = categoryId;
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            if (!String.IsNullOrEmpty(keyword))
            {
                tours = tours.Where(s => s.Name.Contains(keyword) || s.Description.Contains(keyword) || s.Detail.Contains(keyword) || s.SummarySchedule.Contains(keyword));
            }
            if (!String.IsNullOrEmpty(departureId))
            {
                tours = tours.Where(t => t.DepartureId == departureId);
            }

            if (!String.IsNullOrEmpty(destinationId))
            {
                tours = tours.Where(t => t.DestinationId == destinationId);
            }

            switch (duration_range)
            {
                case "all":
                    break;

                case "lte3":
                    tours = tours.Where(t => t.Duration <= 3);
                    break;

                case "4to7":
                    tours = tours.Where(t => t.Duration >= 4 && t.Duration <= 7);
                    break;

                case "gt7":
                    tours = tours.Where(t => t.Duration > 7);
                    break;

                default:
                    break;
            }
            switch (rating)
            {
                case "1":
                    tours = tours.Where(t => t.Rating == 1);
                    break;

                case "2":
                    tours = tours.Where(t => t.Rating == 2);
                    break;

                case "3":
                    tours = tours.Where(t => t.Rating == 3);
                    break;

                case "4":
                    tours = tours.Where(t => t.Rating == 4);
                    break;

                case "5":
                    tours = tours.Where(t => t.Rating == 5);
                    break;
            }

            switch (price_range)
            {
                case "all":
                    break;

                case "lt100":
                    tours = tours.Where(t => t.TourDetails.FirstOrDefault().Price <= 100);
                    break;

                case "100to500":
                    tours = tours.Where(t => t.TourDetails.FirstOrDefault().Price > 100 && t.TourDetails.First().Price <= 500);
                    break;

                case "500t1000":
                    tours = tours.Where(t => t.TourDetails.FirstOrDefault().Price > 500 && t.TourDetails.First().Price <= 1000);
                    break;

                case "gt1000":
                    tours = tours.Where(t => t.TourDetails.FirstOrDefault().Price > 1000);
                    break;

                default:
                    break;
            }

            switch (sortType)
            {
                case "createdAt_asc":
                    tours = tours.OrderBy(s => s.CreatedAt);
                    break;

                case "createdAt_desc":
                    tours = tours.OrderByDescending(s => s.CreatedAt);
                    break;

                case "duration_asc":
                    tours = tours.OrderBy(t => t.Duration);
                    break;

                case "duration_desc":
                    tours = tours.OrderByDescending(t => t.Duration);
                    break;

                case "rating_asc":
                    tours = tours.OrderBy(t => t.Rating);
                    break;

                case "rating_desc":
                    tours = tours.OrderByDescending(t => t.Rating);
                    break;

                default:
                    tours = tours.OrderBy(s => s.CreatedAt);
                    break;
            }
            tours = tours.Include(t => t.TourCategory).Include(t => t.TourDetails);

            return View(tours.ToPagedList(pageNumber, pageSize));
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
            ViewBag.TourDetailPrice = Math.Round(tour.TourDetails.First().Price * (1 - Convert.ToDouble(tour.TourDetails.First().Discount) / 100), 2);
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