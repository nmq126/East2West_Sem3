using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using East2West.Data;
using East2West.Models;
using Newtonsoft.Json;
using PagedList;

namespace East2West.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class OrdersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: Orders
        public ActionResult GetTour(int? page, string departureId, string destinationId, string sortType, int? status, string unit_price_range,
            string ticket_number, string duration_range, string orderId, string username, string startDepartureDay, string endDepartureDay
            , string startCreatedDay, string endCreatedDay, string tourId, string tourDetailId)
        {
            ViewBag.BreadCrumb = "List order tour";
            var orders = db.Orders.Where(o => o.Type == 1)
                .Include(o => o.OrderTours)
                .Include(o => o.Refund)
                .Include(o => o.User);

            ViewBag.Status = status;
            ViewBag.Username = username;
            ViewBag.OrderId = orderId;
            ViewBag.TourId = tourId;
            ViewBag.TourDetail = tourDetailId;
            ViewBag.SortType = sortType;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            ViewBag.UnitPriceRange = unit_price_range;
            ViewBag.TicketNumber = ticket_number;
            ViewBag.DurationRange = duration_range;
            ViewBag.StartDepartureDay = startDepartureDay;
            ViewBag.EndDepartureDay = endDepartureDay;
            ViewBag.StartCreatedDay = startCreatedDay;
            ViewBag.EndCreatedDay = endCreatedDay;
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.TourList = from l in db.Tours select l;

            if (!String.IsNullOrEmpty(orderId))
            {
                orders = orders.Where(o => o.Id.Contains(orderId));
            }

            if (!String.IsNullOrEmpty(tourId))
            {
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.TourId == tourId);
            }

            if (!String.IsNullOrEmpty(tourDetailId))
            {
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetailId.Contains(tourDetailId));
            }

            if (!String.IsNullOrEmpty(username))
            {
                orders = orders.Where(o => o.User.UserName.Contains(username));
            }

            if (!String.IsNullOrEmpty(departureId))
            {
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.DepartureId == departureId);
            }

            if (!String.IsNullOrEmpty(destinationId))
            {
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.DestinationId == destinationId);
            }
            if (!String.IsNullOrEmpty(startDepartureDay) && !String.IsNullOrEmpty(endDepartureDay))
            {
                var start = DateTime.Parse(startDepartureDay);
                var end = DateTime.Parse(endDepartureDay);
                orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.DepartureDay >= start
                                        && o.OrderTours.FirstOrDefault().TourDetail.DepartureDay <= end);
            }
            if (!String.IsNullOrEmpty(startCreatedDay) && !String.IsNullOrEmpty(endCreatedDay))
            {
                var start = DateTime.Parse(startCreatedDay);
                var end = DateTime.Parse(endCreatedDay);
                orders = orders.Where(o => o.CreatedAt >= start && o.CreatedAt <= end);
            }
            switch (status)
            {
                case 3:
                    break;

                case 2:
                    orders = orders.Where(t => t.Status == 2);
                    break;

                case 1:
                    orders = orders.Where(t => t.Status == 1);
                    break;

                case 0:
                    orders = orders.Where(t => t.Status == 0);
                    break;

                case -1:
                    orders = orders.Where(t => t.Status == -1);
                    break;

                case -2:
                    orders = orders.Where(t => t.Status == -2);
                    break;

                default:
                    break;
            }

            switch (duration_range)
            {
                case "all":
                    break;

                case "lte3":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 3);
                    break;

                case "4to7":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration >= 4 && o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 7);
                    break;

                case "gt7":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration > 7);
                    break;

                default:
                    break;
            }

            switch (ticket_number)
            {
                case "all":
                    break;

                case "lte2":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().Quantity <= 2);
                    break;

                case "2to5":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().Quantity > 2 && o.OrderTours.FirstOrDefault().Quantity <= 5);
                    break;

                case "gt5":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().Quantity > 5);
                    break;

                default:
                    break;
            }

            switch (unit_price_range)
            {
                case "lt200":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().UnitPrice < 200);
                    break;

                case "200to500":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().UnitPrice >= 200 && o.OrderTours.FirstOrDefault().UnitPrice <= 500);
                    break;

                case "gt5":
                    orders = orders.Where(o => o.OrderTours.FirstOrDefault().UnitPrice > 500);
                    break;

                case "all":
                default:
                    break;
            }

            switch (sortType)
            {
                case "createdAt_asc":
                    orders = orders.OrderBy(s => s.CreatedAt);
                    break;

                case "createdAt_desc":
                    orders = orders.OrderByDescending(s => s.CreatedAt);
                    break;

                case "departureAt_asc":
                    orders = orders.OrderBy(o => o.OrderTours.FirstOrDefault().TourDetail.DepartureDay);
                    break;

                case "departureAt_desc":
                    orders = orders.OrderByDescending(o => o.OrderTours.FirstOrDefault().TourDetail.DepartureDay);
                    break;

                case "totalPrice_asc":
                    orders = orders.OrderBy(t => t.TotalPrice);
                    break;

                case "totalPrice_desc":
                    orders = orders.OrderBy(t => t.TotalPrice);
                    break;

                default:
                    orders = orders.OrderByDescending(s => s.CreatedAt);
                    break;
            }
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            double revenue = 0;
            foreach (var item in orders.Where(o => o.Status == 1))
            {
                revenue += item.TotalPrice;
            }
            ViewBag.TotalRevenue = revenue;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult GetCar(int? page, int? status, int? hasAC, int? hasDriver, string licensePlate, string brandId, string sortType,
            string modelId, string typeId, string orderId, string username, string startPickUpDay, string endPickUpDay, string locationId,
            string startDropOffDay, string endDropOffDay, string startCreatedDay, string endCreatedDay)
        {
            ViewBag.BreadCrumb = "List order car";

            var orders = db.Orders.Where(o => o.Type == 2)
                .Include(o => o.OrderCars)
                .Include("OrderCars.CarSchedule.Car.CarModel")
                .Include(o => o.Refund)
                .Include(o => o.User);

            ViewBag.LicensePlate = licensePlate;
            ViewBag.Status = status;
            ViewBag.HasAC = hasAC;
            ViewBag.HasDriver = hasDriver;
            ViewBag.Username = username;
            ViewBag.OrderId = orderId;
            ViewBag.SortType = sortType;
            ViewBag.LocationId = locationId;
            ViewBag.ModelId = modelId;
            ViewBag.BrandId = brandId;
            ViewBag.TypeId = typeId;
            ViewBag.StartPickupDay = startPickUpDay;
            ViewBag.EndPickupDay = endPickUpDay;
            ViewBag.StartDropOffDay = startDropOffDay;
            ViewBag.EndDropOffDay = endDropOffDay;
            ViewBag.StartCreatedDay = startCreatedDay;
            ViewBag.EndCreatedDay = endCreatedDay;

            ViewBag.BrandList = from b in db.CarBrands select b;
            ViewBag.ModelList = from m in db.CarModels select m;
            ViewBag.TypeList = from t in db.CarTypes select t;
            ViewBag.LocationList = from l in db.Locations select l;

            if (!String.IsNullOrEmpty(orderId))
            {
                orders = orders.Where(o => o.Id.Contains(orderId));
            }

            if (!String.IsNullOrEmpty(username))
            {
                orders = orders.Where(o => o.User.UserName.Contains(username));
            }

            if (!String.IsNullOrEmpty(brandId))
            {
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.CarModel.CarBrandId == brandId);
            }

            if (!String.IsNullOrEmpty(modelId))
            {
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.CarModelId == modelId);
            }

            if (!String.IsNullOrEmpty(typeId))
            {
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.CarTypeId == typeId);
            }

            if (!String.IsNullOrEmpty(locationId))
            {
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.LocationId == locationId);
            }

            if (!String.IsNullOrEmpty(licensePlate))
            {
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.LisencePlate.Contains(licensePlate));
            }

            if (!String.IsNullOrEmpty(startPickUpDay) && !String.IsNullOrEmpty(endPickUpDay))
            {
                var start = DateTime.Parse(startPickUpDay);
                var end = DateTime.Parse(endPickUpDay);
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.StartDay >= start
                                        && o.OrderCars.FirstOrDefault().CarSchedule.StartDay <= end);
            }
            if (!String.IsNullOrEmpty(startDropOffDay) && !String.IsNullOrEmpty(endDropOffDay))
            {
                var start = DateTime.Parse(startDropOffDay);
                var end = DateTime.Parse(endDropOffDay);
                orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.EndDay >= start
                                        && o.OrderCars.FirstOrDefault().CarSchedule.EndDay <= end);
            }
            if (!String.IsNullOrEmpty(startCreatedDay) && !String.IsNullOrEmpty(endCreatedDay))
            {
                var start = DateTime.Parse(startCreatedDay);
                var end = DateTime.Parse(endCreatedDay);
                orders = orders.Where(o => o.CreatedAt >= start && o.CreatedAt <= end);
            }

            switch (status)
            {
                case 2:
                    orders = orders.Where(t => t.Status == 2);
                    break;

                case 1:
                    orders = orders.Where(t => t.Status == 1);
                    break;

                case 0:
                    orders = orders.Where(t => t.Status == 0);
                    break;

                case -1:
                    orders = orders.Where(t => t.Status == -1);
                    break;

                case -2:
                    orders = orders.Where(t => t.Status == -2);
                    break;

                case 3:
                default:
                    break;
            }
            switch (hasAC)
            {
                case 1:
                    orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasAirConditioner == true);
                    break;

                case 0:
                    orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasAirConditioner == false);
                    break;

                case 2:
                default:
                    break;
            }
            switch (hasDriver)
            {
                case 1:
                    orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasDriver == true);
                    break;

                case 0:
                    orders = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasDriver == false);
                    break;

                case 2:
                default:
                    break;
            }
            switch (sortType)
            {
                case "createdAt_asc":
                    orders = orders.OrderBy(s => s.CreatedAt);
                    break;

                case "totalPrice_asc":
                    orders = orders.OrderBy(t => t.TotalPrice);
                    break;

                case "totalPrice_desc":
                    orders = orders.OrderByDescending(t => t.TotalPrice);
                    break;

                case "createdAt_desc":
                default:
                    orders = orders.OrderByDescending(s => s.CreatedAt);
                    break;
            }
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            double revenue = 0;
            foreach (var item in orders.Where(o => o.Status == 1))
            {
                revenue += item.TotalPrice;
            }
            ViewBag.TotalRevenue = revenue;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }

        public String GetCarDetails(string id)
        {
            if (id == null)
            {
                return "Bad Requets";
            }
            Car car = db.Cars.Include(c => c.Location)
                .Include(c => c.CarModel)
                .Include("CarModel.CarBrand")
                .Include(c => c.CarType)
                .Include(c => c.Location)
                .FirstOrDefault(c => c.Id == id);

            if (car == null)
            {
                return "Car not found";
            }
            var img = "https://res.cloudinary.com/nmqdec6/image/upload/v1655735551/Project%20East2West/default-thumbnail_bd4eth.jpg";
            if (car.Thumbnail != null)
            {
                img = car.Thumbnail.Split(',').ToList<String>().First();
            }
            var obj = new
            {
                id = car.Id,
                model = car.CarModel.Name,
                brand = car.CarModel.CarBrand.Name,
                location = car.Location.Name,
                licensePlate = car.LisencePlate,
                hasAC = car.HasAirConditioner,
                hasDriver = car.HasDriver,
                thumbnail = img
            };
            return JsonConvert.SerializeObject(obj);
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            ViewBag.BreadCrumb = "Order detail";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Include(o => o.OrderCars).Include(o => o.OrderTours).Where(o => o.Id == id).FirstOrDefault();
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public String ChangeStatusOrder(string ids, int status)
        {
            var listId = ids.Split(',').ToList();
            foreach (var itemId in listId)
            {
                if (itemId == null)
                {
                    return "Bad Request";
                }
                Order order = db.Orders.Find(itemId);
                if (order == null)
                {
                    return "Bad request item " + itemId + " not found";
                }
                if (order.Status == 0 || order.Status == 2)
                {
                    return "Bad request! Item " + itemId + " can not change status due to the policy";
                }
                if (status == -1)
                {
                    return "Bad request! Item " + itemId + " status can not be changed to UNPAID due to the policy";
                }
                if (order.Status != -1 & status == 1)
                {
                    return "Bad request! Item " + itemId + " status can not be changed to PAID due to the policy";
                }
                if (order.Status != -2 & status == 2)
                {
                    return "Bad request! Item " + itemId + " status can not be changed to REFUNDED due to the policy";
                }
                if (order.Status != 1 & status == -2)
                {
                    return "Bad request! Item " + itemId + " status can not be changed to PENDING REFUND due to the policy";
                }
                if (order.Status != -1 & status == 0)
                {
                    return "Bad request! Item " + itemId + " status can not be changed to CANCEL due to the policy";
                }
                if (status == 2)
                {
                    var refund = db.Refunds.Find(itemId);
                    if (refund == null)
                    {
                        return "Bad request refund of order " + itemId + " not found";
                    }
                    refund.Status = 1;
                    refund.UpdatedAt = DateTime.Now;
                }
                TimeSpan span = new TimeSpan(1, 0, 0, 0);

                if (status == -2)
                {
                    var presentTime = DateTime.Now;
                    if (order.UpdatedAt != null)
                    {
                        span = presentTime.Subtract((DateTime)order.UpdatedAt);
                    }
                    int percent;
                    switch (span.Days)
                    {
                        case 1:
                            percent = 75;
                            break;

                        case 2:
                            percent = 80;
                            break;

                        case 3:
                            percent = 85;
                            break;

                        case 4:
                            percent = 90;
                            break;

                        case 5:
                        default:
                            percent = 95;
                            break;
                    }
                    var refund = new Models.Refund()
                    {
                        Percent = percent,
                        Status = 0,
                        TotalPrice = order.TotalPrice * (Convert.ToDouble(percent) / 100),
                        CreatedAt = DateTime.Now
                    };
                    order.Refund = refund;
                    if (order.Type == 1)
                    {
                        order.OrderTours.First().TourDetail.AvailableSeat += order.OrderTours.First().Quantity;
                    }
                    else
                    {
                        order.OrderCars.First().CarSchedule.Status = -1;
                    }
                    db.Refunds.Add(refund);
                }
                order.Status = status;
                order.UpdatedAt = DateTime.Now;
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return "Update fail";
            }
            return "Update success";
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