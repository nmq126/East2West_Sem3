﻿using System;
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
    public class CarSchedulesController : Controller
    {
        private DBContext db = new DBContext();

        // GET: CarSchedules
        public ActionResult Index()
        {
            var carSchedules = db.CarSchedules.Include(c => c.Car);
            return View(carSchedules.ToList());
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
            ViewBag.CarId = new SelectList(db.Cars, "Id", "Id");
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
                carSchedule.CreatedAt = carSchedule.UpdatedAt = carSchedule.DeletedAt = DateTime.Now;
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
