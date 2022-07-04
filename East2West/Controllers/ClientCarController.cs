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
using PagedList;

namespace East2West.Controllers
{
    public class ClientCarController : Controller
    {
        private DBContext db = new DBContext();

        public ActionResult GetListCar(string rating, string keyword, int? hasDriver, int? hasAC, string sortType, string licensePlate, string locationId, string brandId, string modelId, string typeId, int? page)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            ViewBag.BrandList = from b in db.CarBrands select b;
            ViewBag.ModelList = from m in db.CarModels select m;
            ViewBag.TypeList = from t in db.CarTypes select t;
            ViewBag.LocationList = from l in db.Locations select l;

            ViewBag.Rating = rating;
            ViewBag.Keyword = keyword;
            ViewBag.HasDriver = hasDriver;
            ViewBag.HasAC = hasAC;
            ViewBag.ModelId = modelId;
            ViewBag.BrandId = brandId;
            ViewBag.TypeId = typeId;
            ViewBag.SortType = sortType;
            ViewBag.LicensePlate = licensePlate;
            ViewBag.LocationId = locationId;

            int pageNumber = (page ?? 1);
            int pageSize = 5;
            var cars = db.Cars.Include(c => c.CarModel)
                .Include("CarModel.CarBrand")
                .Include(c => c.CarType)
                .Include(c => c.Location);

            if (!String.IsNullOrEmpty(keyword))
            {
                cars = cars.Where(s => s.CarModel.Name.Contains(keyword) || s.Description.Contains(keyword) || s.LisencePlate.Contains(keyword) || s.CarModel.CarBrand.Name.Contains(keyword));
            }

            if (!String.IsNullOrEmpty(locationId))
            {
                cars = cars.Where(c => c.LocationId == locationId);
            }

            if (!String.IsNullOrEmpty(typeId))
            {
                cars = cars.Where(c => c.CarTypeId == typeId);
            }

            if (!String.IsNullOrEmpty(modelId))
            {
                cars = cars.Where(c => c.CarModelId == modelId);
            }
            if (!String.IsNullOrEmpty(brandId))
            {
                cars = cars.Where(c => c.CarModel.CarBrandId == brandId);
            }
            switch (hasAC)
            {
                case 2:
                    break;

                case 1:
                    cars = cars.Where(t => t.HasAirConditioner == true);
                    break;

                case 0:
                    cars = cars.Where(t => t.HasAirConditioner == false);
                    break;

                default:
                    break;
            }
            switch (hasDriver)
            {
                case 2:
                    break;

                case 1:
                    cars = cars.Where(t => t.HasDriver == true);
                    break;

                case 0:
                    cars = cars.Where(t => t.HasDriver == false);
                    break;

                default:
                    break;
            }
            switch (rating)
            {
                case "1":
                    cars = cars.Where(t => t.Rating == 1);
                    break;

                case "2":
                    cars = cars.Where(t => t.Rating == 2);
                    break;

                case "3":
                    cars = cars.Where(t => t.Rating == 3);
                    break;

                case "4":
                    cars = cars.Where(t => t.Rating == 4);
                    break;

                case "5":
                    cars = cars.Where(t => t.Rating == 5);
                    break;
            }
            switch (sortType)
            {
                case "createdAt_asc":
                    cars = cars.OrderBy(s => s.CreatedAt);
                    break;

                case "createdAt_desc":
                    cars = cars.OrderByDescending(s => s.CreatedAt);
                    break;

                case "price_asc":
                    cars = cars.OrderBy(t => t.PricePerDay);
                    break;

                case "price_desc":
                    cars = cars.OrderByDescending(t => t.PricePerDay);
                    break;

                case "rating_asc":
                    cars = cars.OrderBy(t => t.Rating);
                    break;

                case "rating_desc":
                    cars = cars.OrderByDescending(t => t.Rating);
                    break;

                default:
                    cars = cars.OrderBy(s => s.CreatedAt);
                    break;
            }
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Details(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
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
            ViewBag.Price = db.Cars.FirstOrDefault(c => c.Id == id).PricePerDay;
            ViewBag.Location = db.Cars.FirstOrDefault(c => c.Id == id).Location.Name;
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }
    }
}