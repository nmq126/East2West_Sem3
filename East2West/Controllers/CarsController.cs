using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using East2West.Data;
using East2West.Models;
using PagedList;

namespace East2West.Controllers
{
    public class CarsController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Cars
        public ActionResult Index(int? status, int? hasAC, string id, string sortType, string licensePlate, string locationId, string brandId, string modelId, string typeId, int? page)
        {
            ViewBag.BreadCrumb = "Car List";
            ViewBag.BrandList = from b in db.CarBrands select b;
            ViewBag.ModelList = from m in db.CarModels select m;
            ViewBag.TypeList = from t in db.CarTypes select t;
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.Status = status;
            ViewBag.HasAC = hasAC;
            ViewBag.ModelId = modelId;
            ViewBag.BrandId = brandId;
            ViewBag.TypeId = typeId;
            ViewBag.SortType = sortType;
            ViewBag.Id = id;
            ViewBag.LicensePlate = licensePlate;

            int pageNumber = (page ?? 1);
            int pageSize = 10;
            var cars = db.Cars.Include(c => c.CarModel)
                .Include("CarModel.CarBrand")
                .Include(c => c.CarType)
                .Include(c => c.Location);

            if (!String.IsNullOrEmpty(id))
            {
                cars = cars.Where(c => c.Id.Contains(id));
            }

            if (!String.IsNullOrEmpty(licensePlate))
            {
                cars = cars.Where(s => s.LisencePlate.Contains(licensePlate));
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

            switch (status)
            {
                case 2:
                    break;
                case 1:
                    cars = cars.Where(t => t.Status == 1);
                    break;
                case 0:
                    cars = cars.Where(t => t.Status == 0);
                    break;
                default:
                    break;
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
                default:
                    cars = cars.OrderBy(s => s.CreatedAt);
                    break;
            }
            return View(cars.ToPagedList(pageNumber, pageSize));
        }

        // GET: Cars/Details/5
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

        // GET: Cars/Create
        public ActionResult Create()
        {
            ViewBag.CarBrandId = new SelectList(db.CarBrands, "Id", "Name");
            ViewBag.CarModelId = new SelectList(db.CarModels, "Id", "Name");
            ViewBag.CarTypeId = new SelectList(db.CarTypes, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car)
        {
            if (ModelState.IsValid)
            {
                car.CreatedAt = car.UpdatedAt = car.DeletedAt = DateTime.Now;
                car.Status = 1;
                do
                {
                    car.Id = String.Concat("CAR_", Guid.NewGuid().ToString("N").Substring(0, 5));
                } while (db.Tours.FirstOrDefault(c => c.Id == car.Id) != null);
                db.Cars.Add(car);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarBrandId = new SelectList(db.CarBrands, "Id", "Name");
            ViewBag.CarModelId = new SelectList(db.CarModels, "Id", "Name");
            ViewBag.CarTypeId = new SelectList(db.CarTypes, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(car);
        }

        // GET: Cars/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarModelId = new SelectList(db.CarModels, "Id", "Name");
            ViewBag.CarTypeId = new SelectList(db.CarTypes, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Car car)
        {
            if (ModelState.IsValid)
            {
                car.UpdatedAt = DateTime.Now;
                if (car.Status == 0)
                {
                    car.DeletedAt = DateTime.Now;
                }
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarModelId = new SelectList(db.CarModels, "Id", "Name");
            ViewBag.CarTypeId = new SelectList(db.CarTypes, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "Name");
            return View(car);
        }

        public String ChangeStatus(string id, int status)
        {
            if (id == null)
            {
                return "Bad Request";
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return "Car not found";
            }
            car.Status = status;
            string newStatus = "ACTIVE";
            if (status == 0)
            {
                newStatus = "DISABLE"; 
            }
            db.SaveChanges();
            return "Car #" + id + " status change to " + newStatus;
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
