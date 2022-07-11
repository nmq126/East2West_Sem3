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
    //[Authorize(Roles = "Admin")]
    public class FlightsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Flights
        public ActionResult Index(string id, string sortType, int? page, string keyword,string departureId,string destinationId,  int? status)
        {
            ViewBag.BreadCrumb = "Flight List";
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.Id = id;
            ViewBag.SortType = sortType;
            ViewBag.Status = status;
            ViewBag.Keywork = keyword;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            var flights = db.Flights.Include(f => f.LocationDeparture).Include(f => f.LocationDestination);

            flights = (status > 0) ? flights.Where(M => M.Status == status) : flights;
            if (!String.IsNullOrEmpty(id))
            {
                flights = flights.Where(t => t.Id == id);
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                flights = flights.Where(t => t.LocationDeparture.Name.Contains(keyword) || t.Detail.Contains(keyword) || t.Description.Contains(keyword) ||  t.LocationDestination.Name.Contains(keyword) || t.Detail.Contains(keyword));
            }
            if (!String.IsNullOrEmpty(departureId))
            {
                flights = flights.Where(t => t.DepartureId == departureId);
            }
            if (!String.IsNullOrEmpty(destinationId))
            {
                flights = flights.Where(t => t.DestinationId == destinationId);
            }
            switch (sortType)
            {
                case "createdAt_asc":
                    flights = flights.OrderBy(s => s.CreatedAt);
                    break;
                case "createdAt_desc":
                    flights = flights.OrderByDescending(s => s.CreatedAt);
                    break;
                case "duration_asc":
                    flights = flights.OrderBy(t => t.Duration);
                    break;
                case "duration_desc":
                    flights = flights.OrderByDescending(t => t.Duration);
                    break;
                default:
                    flights = flights.OrderBy(s => s.CreatedAt);
                    break;
            }

            return View(flights.ToPagedList(pageNumber, pageSize));
        }

        // GET: Flights/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.BreadCrumb = "Flight Detail";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flights.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            var locationName = db.Locations.ToList().Where(M => M.Id == flight.LocationDestination.Id);
            var departureName = db.Locations.ToList().Where(M => M.Id == flight.LocationDeparture.Id);
            ViewBag.LocationName = locationName.FirstOrDefault().Name;
            ViewBag.DepartureName = departureName.FirstOrDefault().Name;
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Create Flight";

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
            ViewBag.BreadCrumb = "Edit Flight";

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

        public String ChangeStatus(string id, int status)
        {
            if (id == null)
            {
                return "Bad Request";
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return "Hotel not found";
            }
            hotel.Status = status;
            string newStatus = "ACTIVE";
            if (status == 0)
            {
                newStatus = "DISABLE";
            }
            db.SaveChanges();
            return "Hotel #" + id + "status change to " + newStatus;
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