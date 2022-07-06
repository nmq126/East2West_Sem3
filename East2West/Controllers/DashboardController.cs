using East2West.Data;
using East2West.Models.ChartModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class DashboardController : Controller
    {
        private DBContext db = new DBContext();
        private readonly string tourDurationTitle = "Revenue by tour package duration share";
        private readonly string tourCategoryTitle = "Revenue by tour package category share";
        private readonly string tourSeasonTitle = "Revenue by season share";
        private static string tourDateRange;
        private readonly string carModelTitle = "Revenue by tour package duration share";
        private readonly string carTypeTitle = "Revenue by tour package category share";
        private readonly string carSeasonTitle = "Revenue by season share";
        private static string carDateRange;
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "Dashboard";
            ViewBag.TotalOrder = db.Orders.Count();
            ViewBag.TotalUser = db.Users.Count();
            ViewBag.TotalRevenue = db.Orders.Where(x => x.Status == 1).Sum(x => x.TotalPrice);
            tourDateRange = "All time";
            ViewBag.DataPoints = GetOrderTourDataByDuration(db.Orders.Where(x => x.Type == 1 && x.Status == 1));

            return View();
        }

        public String GetTourChartData(string typeId, string startDay, string endDay)
        {
            var orders = GetOrderInDateRange(startDay, endDay);
            if (typeId == "2")
            {
                return GetOrderTourDataByDuration(orders);
            }
            if (typeId == "1")
            {
                return GetOrderTourDataByCategory(orders);
            }
            if (typeId == "0")
            {
                return GetOrderTourDataBySeason(orders);
            }
            return null;
        }

        public IQueryable<Models.Order> GetOrderInDateRange(string startDay, string endDay)
        {
            var orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1);
            if (!String.IsNullOrWhiteSpace(startDay) && !String.IsNullOrWhiteSpace(endDay))
            {
                var start = DateTime.Parse(startDay);
                var end = DateTime.Parse(endDay);
                orders = orders.Where(o => o.CreatedAt >= start && o.CreatedAt <= end);
                tourDateRange = startDay + " - " + endDay;
            }
            return orders;
        }

        private String GetOrderTourDataByDuration(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 3);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Less than 3 days", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Less than 3 days", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration >= 4 && o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 7);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("4 to 7 days", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("4 to 7 days", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration > 7);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Over 7 days", 0));

            }else
            {
                dataPoints.Add(new DataPoint("Over 7 days", ordersItem.Sum(o => o.TotalPrice)));
            }
            var obj = new
            {
                title = tourDurationTitle,
                date = tourDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }

        private String GetOrderTourDataByCategory(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var categories = from c in db.TourCategories select c;
            foreach (var item in categories)
            {
                var ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.TourCategoryId == item.Id);
                if (ordersItem == null || ordersItem.Count() == 0)
                {
                    dataPoints.Add(new DataPoint(item.Name, 0));

                }
                else
                {
                    dataPoints.Add(new DataPoint(item.Name, ordersItem.Sum(o => o.TotalPrice)));
                }
            }
            var obj = new
            {
                title = tourCategoryTitle,
                date = tourDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }

        private String GetOrderTourDataBySeason(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();

            var ordersItem = orders.Where(x => new[] { 3, 4, 5 }.Contains(x.CreatedAt.Month));
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Spring", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Spring", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 6, 7, 8 }.Contains(x.CreatedAt.Month));
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Summer", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("Summer", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 9, 10, 11 }.Contains(x.CreatedAt.Month));
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Fall", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Fall", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 12, 1, 2 }.Contains(x.CreatedAt.Month));
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Winter", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Winter", ordersItem.Sum(o => o.TotalPrice)));
            }
            var obj = new
            {
                title = tourSeasonTitle,
                date = tourDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }
    }
}