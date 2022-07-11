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
    [Authorize(Roles = "Admin")]
    public class CarSchedulesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: CarSchedules
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var carSchedules = db.CarSchedules
                .Include(c => c.Car)
                .Include("Car.CarModel")
                .Include("Car.CarType")
                .Include("Car.CarModel.CarBrand")
                .OrderBy(c => c.CreatedAt);
            return View(carSchedules.ToPagedList(pageNumber, pageSize));
        }

        // GET: CarSchedules/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSchedule carSchedule = db.CarSchedules.Find(id);
            if (carSchedule == null)
            {
                return HttpNotFound();
            }
            return View(carSchedule);
        }

        // GET: CarSchedules/Create
        public ActionResult Create()
        {
            ViewBag.CarId = new SelectList(db.Cars.Where(c => c.Status == 1), "Id", "Id");
            return View();
        }

        // POST: CarSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarSchedule carSchedule)
        {
            if (ModelState.IsValid)
            {
                var car = db.Cars.Include(c => c.CarSchedules).Where(c => c.Id == carSchedule.CarId).FirstOrDefault();
                if(car == null)
                {
                    return HttpNotFound();
                }
                //validate date range overlap
                var thisCarSchedule = car.CarSchedules;
                foreach (var item in thisCarSchedule)
                {
                    if (carSchedule.StartDay <= item.EndDay && carSchedule.EndDay >= item.StartDay)
                    {
                        TempData["data"] = "Cannot create schedule because your date range overlap with this schedule: " + item.StartDay.ToShortDateString() + " - " + item.EndDay.ToShortDateString();
                        ViewBag.CarId = new SelectList(db.Cars, "Id", "CarModelId", carSchedule.CarId);
                        return View(carSchedule);
                    }
                }
                carSchedule.CreatedAt = DateTime.Now;
                carSchedule.Status = 0;
                do
                {
                    carSchedule.Id = String.Concat("CARSCH_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Tours.FirstOrDefault(c => c.Id == carSchedule.Id) != null);

                db.CarSchedules.Add(carSchedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarId = new SelectList(db.Cars, "Id", "CarModelId", carSchedule.CarId);
            return View(carSchedule);
        }

        private bool ValidateDateRange()
        {
            return true;
        }

        // GET: CarSchedules/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSchedule carSchedule = db.CarSchedules.Find(id);
            if (carSchedule == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "CarModelId", carSchedule.CarId);
            return View(carSchedule);
        }

        // POST: CarSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CarId,StartDay,EndDay,Status,CreatedAt,UpdatedAt,DeletedAt")] CarSchedule carSchedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carSchedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarId = new SelectList(db.Cars, "Id", "CarModelId", carSchedule.CarId);
            return View(carSchedule);
        }

        // GET: CarSchedules/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarSchedule carSchedule = db.CarSchedules.Find(id);
            if (carSchedule == null)
            {
                return HttpNotFound();
            }
            return View(carSchedule);
        }

        // POST: CarSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CarSchedule carSchedule = db.CarSchedules.Find(id);
            db.CarSchedules.Remove(carSchedule);
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
