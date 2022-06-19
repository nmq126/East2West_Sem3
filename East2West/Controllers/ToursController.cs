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

namespace East2West.Controllers
{
    public class ToursController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Tours
        public ActionResult Index()
        {
            var tours = db.Tours.Include(t => t.LocationDeparture).Include(t => t.LocationDestination);
            return View(tours.ToList());
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
                    tour.Id = String.Concat("TOUR", Guid.NewGuid().ToString("N").Substring(0, 5));
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
