using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class TourSchedulesController : Controller
    {
        // GET: TourSchedules
        public ActionResult Index()
        {
            return View();
        }
    }
}