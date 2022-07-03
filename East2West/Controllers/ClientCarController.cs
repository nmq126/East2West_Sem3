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

        public ActionResult GetListCar(int? hasAC, string id, string sortType, string licensePlate, string locationId, string brandId, string modelId, string typeId, int? page)
        {
            ViewBag.BrandList = from b in db.CarBrands select b;
            ViewBag.ModelList = from m in db.CarModels select m;
            ViewBag.TypeList = from t in db.CarTypes select t;
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.HasAC = hasAC;
            ViewBag.ModelId = modelId;
            ViewBag.BrandId = brandId;
            ViewBag.TypeId = typeId;
            ViewBag.SortType = sortType;
            ViewBag.LicensePlate = licensePlate;

            var cars = db.Cars.Include(c => c.CarModel)
                .Include("CarModel.CarBrand")
                .Include(c => c.CarType)
                .Include(c => c.Location);
            return View(cars.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Include(c => c.Location)
                .Include(c => c.CarModel)
                .Include("CarModel.CarBrand")
                .Include(c => c.CarType)
                .Include(c => c.CarSchedules)
                .FirstOrDefault(c => c.Id == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
    }
}