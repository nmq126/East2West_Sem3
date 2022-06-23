using East2West.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using East2West.Models;

namespace East2West.Controllers
{
    public class ClientTourController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult GetListTour()
        {
            var tour = db.Tours.Include(o => o.TourDetails);
            return View(tour.ToList());
        }

        public ActionResult Details(string id)
        {
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
    }
}