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
using Newtonsoft.Json;
using PagedList;

namespace East2West.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ToursController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Tours
        public ActionResult Index(int? status, string id, string sortType, string keyword, string duration_range,
            string departureId, string destinationId, string categoryId, int? page)
        {
            ViewBag.BreadCrumb = "List Tour";
            var tours = from t in db.Tours select t;

            ViewBag.CategoryList = from c in db.TourCategories select c;
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.Status = status;
            ViewBag.Keyword = keyword;
            ViewBag.Id = id;
            ViewBag.SortType = sortType;
            ViewBag.DurationRange = duration_range;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            ViewBag.CategoryId = categoryId;
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            if (!String.IsNullOrEmpty(id))
            {
                tours = tours.Where(t => t.Id.Contains(id));
            }

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

            if (!String.IsNullOrEmpty(categoryId))
            {
                tours = tours.Where(t => t.TourCategoryId == categoryId);
            }

            switch (status)
            {
                case 2:
                    break;
                case 1:
                    tours = tours.Where(t => t.Status == 1);
                    break;
                case 0:
                    tours = tours.Where(t => t.Status == 0);
                    break;
                default:
                    break;
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
                    tours = tours.OrderByDescending(s => s.CreatedAt);
                    break;
            }
            tours = tours.Include(t => t.TourCategory);
            return View(tours.ToPagedList(pageNumber, pageSize));
        }

        // GET: Tours/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.BreadCrumb = "Tour detail";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Include(t => t.TourSchedules).Include(t => t.TourDetails).FirstOrDefault(t => t.Id == id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // GET: Tours/Create
        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Create Tour";

            ViewBag.TourCategoryId = new SelectList(db.TourCategories, "Id", "Name");
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name");
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tour tour)
        {
            if (ModelState.IsValid)
            {
                tour.Rating = 5;
                tour.Status = 1;
                tour.CreatedAt = DateTime.Now;
                do
                {
                    tour.Id = String.Concat("TOUR_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Tours.FirstOrDefault(c => c.Id == tour.Id) != null);
                if (tour.TourSchedules == null || tour.TourSchedules.Count() == 0)
                {
                    return RedirectToAction("Index");
                }

                // section
                if (tour.TourSchedules != null && tour.TourSchedules.Count() > 0)
                {
                    var order = 1;
                    foreach (var item in tour.TourSchedules)
                    {
                        do
                        {
                            item.Id = String.Concat("TRSCH_", Guid.NewGuid().ToString("N").Substring(0, 5));
                        } while (db.TourSchedules.FirstOrDefault(s => s.Id == item.Id) != null);
                        //thu tu trong tour
                        item.ScheduleOrder = order;
                        order++;
                    }
                }
                db.Tours.Add(tour);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TourCategoryId = new SelectList(db.TourCategories, "Id", "Name", tour.TourCategoryId);
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", tour.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", tour.DestinationId);
            return View(tour);
        }

        public PartialViewResult AddNewTourSchedule(int number)
        {
            ViewBag.Number = number;
            return PartialView("TourScheduleRow", new TourSchedule());
        }

        // GET: Tours/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.BreadCrumb = "Edit Tour";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Include(t => t.TourSchedules).FirstOrDefault(t => t.Id == id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourCategoryId = new SelectList(db.TourCategories, "Id", "Name", tour.TourCategoryId);
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", tour.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", tour.DestinationId);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                tour.UpdatedAt = DateTime.Now;
                if (tour.Status == 0)
                {
                    tour.DeletedAt = DateTime.Now;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", tour.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", tour.DestinationId);
            return View(tour);
        }
        

        public String ChangeStatus(string ids, int status)
        {
            var listId = ids.Split(',').ToList();
            string newStatus = "ACTIVE";
            if (status == 0)
            {
                newStatus = "DISABLE";
            }
            foreach (var itemId in listId)
            {
                if (itemId == null)
                {
                    return "Bad Request";
                }
                Tour tour = db.Tours.Find(itemId);
                if (tour == null)
                {
                    return "Bad request tour " + itemId + " not found";
                }
                tour.Status = status;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return "Update fail";
            }
            if (listId.Count > 1)
            {
                return "Update success";
            }
            return  "Tour #" + listId[0] + " status change to " + newStatus;
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
