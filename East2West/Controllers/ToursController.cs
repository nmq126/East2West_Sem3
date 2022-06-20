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
    public class ToursController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Tours
        public ActionResult Index(string id, string sortType, string keyword, string departureId, string destinationId, int? page)
        {
            ViewBag.BreadCrumb = "Tour List";
            var tours = from t in db.Tours select t;

            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.Keyword = keyword;
            ViewBag.Id = id;
            ViewBag.SortType = sortType;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
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
            return View(tours.ToPagedList(pageNumber, pageSize));
        }

        // GET: Tours/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
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
                tour.CreatedAt = tour.UpdatedAt = tour.DeletedAt = DateTime.Now;
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
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", tour.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", tour.DestinationId);
            return View(tour);
        }

        // POST: Tours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DepartureId,DestinationId,Name,Description,Detail,Thumbnail,Duration,Rating,Policy,SummarySchedule,Status,CreatedAt,UpdatedAt,DeletedAt")] Tour tour)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tour).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", tour.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", tour.DestinationId);
            return View(tour);
        }

        // GET: Tours/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tour tour = db.Tours.Find(id);
            if (tour == null)
            {
                return HttpNotFound();
            }
            return View(tour);
        }

        // POST: Tours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Tour tour = db.Tours.Find(id);
            db.Tours.Remove(tour);
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
