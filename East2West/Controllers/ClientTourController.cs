using East2West.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
    }
}