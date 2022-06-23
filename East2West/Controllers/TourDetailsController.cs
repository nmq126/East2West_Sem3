using East2West.Data;
using East2West.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class TourDetailsController : Controller
    {
        private DBContext db = new DBContext();
        // GET: TourDetails
        public ActionResult Index(int? page)
        {
            ViewBag.BreadCrumb = "Tour Detail List";
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var tourDetails = from t in db.TourDetails select t;
            tourDetails = tourDetails.OrderBy(x => x.DepartureDay);
            return View(tourDetails.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            ViewBag.BreadCrumb = "Create Tour detail";

            ViewBag.TourId = new SelectList(db.Tours, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TourDetail tourDetail)
        {
            if (ModelState.IsValid)
            {
                tourDetail.CreatedAt = tourDetail.UpdatedAt = tourDetail.DeletedAt = DateTime.Now;
                do
                {
                    tourDetail.Id = String.Concat("TOURDT_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Tours.FirstOrDefault(c => c.Id == tourDetail.Id) != null);
                
                db.TourDetails.Add(tourDetail);
                db.SaveChanges();
                return RedirectToAction("Index");   
            }

            ViewBag.TourId = new SelectList(db.Tours, "Id", "Name");
            return View(tourDetail);
        }
    }
}