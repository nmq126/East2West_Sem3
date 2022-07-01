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
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "Dashboard";
            ViewBag.TotalOrder = db.Orders.Count();
            ViewBag.TotalUser = db.Users.Count();
            ViewBag.TotalRevenue = db.Orders.Where(x => x.Status == 1).Sum(x => x.TotalPrice);

            ViewBag.PieChartTitle = "Revenue by tour package duration share";

            ViewBag.DataPoints = GetOrderTourDataByDuration();

            return View();
        }

        private String GetOrderTourDataByDuration()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            var orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 3);
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Less than 3 days", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Less than 3 days", orders.Sum(o => o.TotalPrice)));
            }
            orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration >= 4 && o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration <= 7);
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("4 to 7 days", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("4 to 7 days", orders.Sum(o => o.TotalPrice)));
            }
            orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.Duration > 7);
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Over 7 days", 0));

            }else
            {
                dataPoints.Add(new DataPoint("Over 7 days", orders.Sum(o => o.TotalPrice)));
            }

            return JsonConvert.SerializeObject(dataPoints);
        }

        private String GetOrderTourDataByCategory()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();
            var categories = from c in db.TourCategories select c;
            foreach (var item in categories)
            {
                var orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(o => o.OrderTours.FirstOrDefault().TourDetail.Tour.TourCategoryId == item.Id);
                if (orders == null || orders.Count() == 0)
                {
                    dataPoints.Add(new DataPoint(item.Name, 0));

                }
                else
                {
                    dataPoints.Add(new DataPoint(item.Name, orders.Sum(o => o.TotalPrice)));
                }
            }
            
            return JsonConvert.SerializeObject(dataPoints);
        }

        private String GetOrderTourDataBySeason()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            var orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 3, 4, 5 }.Contains(x.CreatedAt.Month));
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Spring", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Spring", orders.Sum(o => o.TotalPrice)));
            }
            orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 6, 7, 8 }.Contains(x.CreatedAt.Month));
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Summer", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("Summer", orders.Sum(o => o.TotalPrice)));
            }
            orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 9, 10, 11 }.Contains(x.CreatedAt.Month));
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Fall", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Fall", orders.Sum(o => o.TotalPrice)));
            }
            orders = db.Orders.Where(x => x.Type == 1 && x.Status == 1).Where(x => new[] { 12, 1, 2 }.Contains(x.CreatedAt.Month));
            if (orders == null || orders.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Winter", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Winter", orders.Sum(o => o.TotalPrice)));
            }

            return JsonConvert.SerializeObject(dataPoints);
        }

        public String ChangeType(string typeId)
        {
            if (typeId == "2")
            {
                return GetOrderTourDataByDuration();
            }
            if (typeId == "1")
            {
                return GetOrderTourDataByCategory();
            }
            if (typeId == "0")
            {
                return GetOrderTourDataBySeason();
            }
            return null;
        }

    }
}