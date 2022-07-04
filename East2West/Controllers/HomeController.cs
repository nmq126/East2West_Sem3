using East2West.Data;
using East2West.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace East2West.Controllers
{
    public class HomeController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult Index()
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View();
        }

        public ActionResult About()
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ThankYou()
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            return View();
        }
    }
}