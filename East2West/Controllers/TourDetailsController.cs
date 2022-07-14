using East2West.Data;
using East2West.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using static East2West.Models.TourDetail;

namespace East2West.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TourDetailsController : Controller
    {
        private DBContext db = new DBContext();
        // GET: TourDetails
        public ActionResult Index(int? page, string tourId, string id)
        {
            ViewBag.TourId = tourId;
            ViewBag.Id = id;
            ViewBag.TourList = from t in db.Tours select t;

            ViewBag.BreadCrumb = "Tour Detail List";
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var tourDetails = from t in db.TourDetails select t;

            if (!String.IsNullOrEmpty(id))
            {
                tourDetails = tourDetails.Where(o => o.Id.Contains(id));
            }

            if (!String.IsNullOrEmpty(tourId))
            {
                tourDetails = tourDetails.Where(o => o.TourId == tourId);
            }

            tourDetails = tourDetails.OrderBy(x => x.DepartureDay);
            return View(tourDetails.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Create Tour detail";

            ViewBag.TourId = new SelectList(db.Tours.Where(t => t.Status == 1), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourDetail tourDetail)
        {
            if (ModelState.IsValid)
            {
                tourDetail.CreatedAt = DateTime.Now;
                do
                {
                    tourDetail.Id = String.Concat("TOURDT_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Tours.FirstOrDefault(c => c.Id == tourDetail.Id) != null);
                
                db.TourDetails.Add(tourDetail);
                db.SaveChanges();
                return RedirectToAction("Index");   
            }

            ViewBag.TourId = new SelectList(db.Tours.Where(t => t.Status == 1), "Id", "Name");
            return View(tourDetail);
        }

        public ActionResult Details(string id)
        {
            ViewBag.BreadCrumb = "Tour detail";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourDetail tourDetail = db.TourDetails.FirstOrDefault(t => t.Id == id);
            if (tourDetail == null)
            {
                return HttpNotFound();
            }
            return View(tourDetail);
        }

        public ActionResult Edit(string id)
        {
            ViewBag.BreadCrumb = "Edit Tour detail";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TourDetail tourDetail = db.TourDetails.FirstOrDefault(t => t.Id == id);
            if (tourDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.TourId = new SelectList(db.Tours, "Id", "Name");
            return View(tourDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TourDetail tourDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tourDetail).State = EntityState.Modified;
                tourDetail.UpdatedAt = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TourId = new SelectList(db.Tours, "Id", "Name");
            return View(tourDetail);
        }
    }
}