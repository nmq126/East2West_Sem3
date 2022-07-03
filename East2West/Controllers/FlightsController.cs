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
    public class FlightsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Flights
        public ActionResult Index()
        {
            var flights = db.Flights.Include(f => f.LocationDeparture).Include(f => f.LocationDestination);
            return View(flights.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationName = db.Locations.Where(M => M.Id == flight.Id).FirstOrDefault().Name; 
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name");
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Flights/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Thumbnail,IsRoundTicket,DepartureId,DestinationId,DepartureAt,Duration,Price,ReturnAt,Detail,Status,CreatedAt,UpdatedAt,DeletedAt")] Flight flight)
        {
            flight.CreatedAt = DateTime.Now;
            flight.Status = 1;
            flight.UpdatedAt = null;
            flight.DeletedAt = null;
            do
            {
                flight.Id = String.Concat("FLIGHT_", Guid.NewGuid().ToString("N").Substring(0, 7));
            } while (db.Flights.FirstOrDefault(c => c.Id == flight.Id) != null);

            if (ModelState.IsValid)
            {
                db.Flights.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", flight.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", flight.DestinationId);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", flight.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", flight.DestinationId);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "Id,Thumbnail,IsRoundTicket,DepartureId,DestinationId,DepartureAt,Duration,Price,ReturnAt,Detail,Status,CreatedAt,UpdatedAt,DeletedAt")] Flight flight)
        {
            flight.UpdatedAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartureId = new SelectList(db.Locations, "Id", "Name", flight.DepartureId);
            ViewBag.DestinationId = new SelectList(db.Locations, "Id", "Name", flight.DestinationId);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Flight flight = db.Flights.Find(id);
            flight.DeletedAt = DateTime.Now;
            db.Entry(flight).State = EntityState.Modified;
            //db.Flights.Remove(flight);
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
