using East2West.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using East2West.Models;
using Microsoft.AspNet.Identity;

namespace East2West.Controllers
{
    public class ClientCarController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult GetListCar()
        {
            var cars = db.Cars.Include(c => c.CarModel)
                .Include("CarModel.CarBrand")
                .Include(c => c.CarType)
                .Include(c => c.Location);
            return View(cars.ToList());
        }
    }
}