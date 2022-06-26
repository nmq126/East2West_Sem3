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
using PagedList;


namespace East2West.Controllers
{
    public class HotelsController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Hotels
        public ActionResult Index(int? status, string id, string sortType, string keyword, string duration_range, string locationId, int? page)

        {
            ViewBag.BreadCrumb = "Hotel List";
            //var hotels = from h in db.Hotels select h;
            var hotels = db.Hotels.Include(h => h.Location);
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.Status = status;
            ViewBag.Id = id;
            ViewBag.SortType = sortType;
            ViewBag.Keyword = keyword;
            ViewBag.DurationRange = duration_range;
            ViewBag.LocationId = locationId;
            ViewBag.Page = page;
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            if (!String.IsNullOrEmpty(id))
            {
                hotels = hotels.Where(h => h.Id == id);
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                hotels = hotels.Where(s => s.Name.Contains(keyword) || s.Description.Contains(keyword) || s.Detail.Contains(keyword) || s.Address.Contains(keyword));
            }
            if (!String.IsNullOrEmpty(locationId))
            {
                hotels = hotels.Where(t => t.LocationId == locationId);
            }
            switch (status)
            {
                case 2:
                    break;
                case 1:
                    hotels = hotels.Where((t) => t.Status == 1);
                    break;
                case 0:
                    hotels = hotels.Where(t => t.Status == 0);
                    break;
            }
            switch (sortType)
            {
                case "createdAt_asc":
                    hotels = hotels.OrderBy(s => s.CreatedAt);
                    break;
                case "createdAt_desc":
                    hotels = hotels.OrderByDescending(s => s.CreatedAt);
                    break;
                case "price_asc":
                    hotels = hotels.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    hotels = hotels.OrderByDescending(s => s.Price);
                    break;
                case "rating_asc":
                    hotels = hotels.OrderBy(t => t.Rating);
                    break;
                case "rating_desc":
                    hotels = hotels.OrderByDescending(t => t.Rating);
                    break;
                default:
                    hotels = hotels.OrderBy(s => s.CreatedAt);
                    break;
            }
            return View(hotels.ToPagedList(pageNumber, pageSize));
        }
        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Create Hotel";

            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                hotel.Status = 1;
                hotel.CreatedAt = hotel.UpdatedAt = hotel.DeletedAt = DateTime.Now;
                do
                {
                    hotel.Id = String.Concat("HT_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Hotels.FirstOrDefault(c => c.Id == hotel.Id) != null);
                // section
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Locationid = new SelectList(db.Locations, "Id", "Name", hotel.LocationId);
            return View(hotel);
        }
        // GET: Hotels/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.BreadCrum = "Hotel detail";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Include(h => h.Location).FirstOrDefault(h => h.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }
        // GET: Tours/Edit/5
        public ActionResult Edit(string id)
        {
            ViewBag.BreadCrumb = "Edit Hotel";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Include(h => h.Location).FirstOrDefault(t => t.Id == id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name", hotel.LocationId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Thumbnail,LocationId,Rating,Name,Address,Price,Description,Detail,Status,CreatedAt,UpdatedAt,DeletedAt")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                hotel.UpdatedAt = DateTime.Now;
                if (hotel.Status == 0)
                {
                    hotel.DeletedAt = DateTime.Now;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Locationid = new SelectList(db.Locations, "Id", "Name", hotel.LocationId);
            return View(hotel);
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