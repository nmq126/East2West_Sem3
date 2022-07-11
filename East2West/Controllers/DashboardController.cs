using East2West.Data;
using East2West.Models.ChartModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private DBContext db = new DBContext();
        private readonly string tourDurationTitle = "Revenue by tour package duration share";
        private readonly string tourCategoryTitle = "Revenue by tour package category share";
        private readonly string tourPriceTitle = "Revenue by tour ticket price range share";
        private readonly string seasonTitle = "Revenue by season share";
        private static string tourDateRange;
        private readonly string carModelTitle = "Revenue by car model share";
        private readonly string carTypeTitle = "Revenue by car type share";
        private readonly string carACTitle = "Revenue by air-conditioned car share";
        private readonly string carDriverTitle = "Revenue by car having driver share";
        private static string carDateRange;
        private readonly string[] ListofMonth = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
        // GET: Dashboard
        public ActionResult Index()
        {
            ViewBag.BreadCrumb = "Dashboard";
            ViewBag.TotalOrder = db.Orders.Count();
            ViewBag.TotalUser = db.Users.Count();
            ViewBag.TotalRevenue = db.Orders.Where(x => x.Status == 1).Sum(x => x.TotalPrice).ToString("C", CultureInfo.GetCultureInfo("en-US"));
            tourDateRange = carDateRange = "All time";

            ViewBag.DataTour = GetOrderTourDataByDuration(db.Orders.Where(x => x.Type == 1 && x.Status == 1));
            ViewBag.DataCar = GetOrderCarDataByModel(db.Orders.Where(x => x.Type == 2 && x.Status == 1));
            ViewBag.DataSaleChart = GetSaleChartData(2022);
            ViewBag.LatestOrders = db.Orders.OrderByDescending(o => o.CreatedAt).Take(10);
            ViewBag.LatestUsers = db.Users.OrderByDescending(o => o.CreatedAt).Take(5);
            var bestTour = FindBestSellingTour().Split(',').ToList();
            ViewBag.BestTour = db.Tours.Find(bestTour[0]);
            ViewBag.BestTourTicket = bestTour[1];
            ViewBag.BestTourSale = String.Format("{0:C}", bestTour[2]);
            return View();
        }
        private string FindBestSellingTour()
        {
            var odt = db.OrderTours.Where(o => o.Order.Status == 1)
                .GroupBy(o => o.TourDetailId)
                .OrderByDescending(o => o.Sum(oi => oi.Quantity))
                .Select(o => new 
                { 
                    Id = o.Key,
                    Quantity = o.Sum(oi => oi.Quantity),
                    TotalSale = o.Sum(oi => oi.Quantity * oi.UnitPrice)
                });
            string keyOfMaxValue = "";
            int maxQuantity = 0;
            double maxTotalSale = 0;
            foreach (var item in odt)
            {
                if (item.Quantity > maxQuantity)
                {
                    maxQuantity = item.Quantity;
                    var x = db.TourDetails.Where(t => t.Id == item.Id).Select(t => new { Id = t.TourId }).First();
                    keyOfMaxValue = x.Id;
                    maxTotalSale = item.TotalSale;
                }
            }
            return keyOfMaxValue + "," + maxQuantity + "," + maxTotalSale;
        }
        public String GetSaleChartData(int year)
        {
            List<DataPoint> DataRevenue = new List<DataPoint>();
            List<DataPoint> DataSale = new List<DataPoint>();
            for (int i = 0; i <= 11; i++)
            {
                var month = ListofMonth[i];
                var ordersItem = db.Orders.Where(s => s.CreatedAt.Month == i+1 && s.CreatedAt.Year == year);
                if (!ordersItem.Any())
                {
                    DataRevenue.Add(new DataPoint(month, 0));
                    DataSale.Add(new DataPoint(month, 0));

                }
                else
                {
                    DataRevenue.Add(new DataPoint(month, ordersItem.Sum(o => o.TotalPrice)));
                    DataSale.Add(new DataPoint(month, ordersItem.Count()));
                }
            }
            var obj = new
            {
                title = "Monthly Sales Data in " + year,
                data1 = DataRevenue,
                data2 = DataSale
            };
            return JsonConvert.SerializeObject(obj);
        }
        public String GetTourChartData(string typeId, string startDay, string endDay)
        {
            var orders = GetOrderInDateRange(startDay, endDay, 1);
            if (typeId == "3")
            {
                return GetOrderTourDataByTicketPrice(orders);
            }
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
                return GetOrderDataBySeason(orders, 1);
            }
            return null;
        }
        public String GetCarChartData(string typeId, string startDay, string endDay)
        {
            var orders = GetOrderInDateRange(startDay, endDay, 2);
            if (typeId == "3")
            {
                return GetOrderCarDataByAC(orders);
            }
            if (typeId == "4")
            {
                return GetOrderCarDataByDriver(orders);
            }
            if (typeId == "2")
            {
                return GetOrderCarDataByModel(orders);
            }
            if (typeId == "1")
            {
                return GetOrderCarDataByType(orders);
            }
            if (typeId == "0")
            {
                return GetOrderDataBySeason(orders, 2);
            }
            return null;
        }
        private String GetOrderDataBySeason(IQueryable<Models.Order> orders, int type)
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
            string date;
            if (type == 1)
            {
                date = tourDateRange;
            }else
            {
                date = carDateRange;
            }
            var obj = new
            {
                title = seasonTitle,
                date = date,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }

        private IQueryable<Models.Order> GetOrderInDateRange(string startDay, string endDay, int type)
        {
            var orders = db.Orders.Where(x => x.Type == type && x.Status == 1);
            if (!String.IsNullOrWhiteSpace(startDay) && !String.IsNullOrWhiteSpace(endDay))
            {
                var start = DateTime.Parse(startDay);
                var end = DateTime.Parse(endDay);
                orders = orders.Where(o => o.CreatedAt >= start && o.CreatedAt <= end);
                if (type == 1)
                {
                    tourDateRange = startDay + " - " + endDay;
                }
                else
                {
                    carDateRange = startDay + " - " + endDay;
                }
            }
            
            return orders;
        }
        private String GetOrderTourDataByTicketPrice(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().UnitPrice < 200);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Less than $200", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Less than $200", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().UnitPrice >= 200 && o.OrderTours.FirstOrDefault().UnitPrice <= 500);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("$200 to $500", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("$200 to $500", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(o => o.OrderTours.FirstOrDefault().UnitPrice > 500);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Greater than $500", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Greater than $500", ordersItem.Sum(o => o.TotalPrice)));
            }
            var obj = new
            {
                title = tourPriceTitle,
                date = tourDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
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

            }
            else
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

        private String GetOrderCarDataByModel(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var models = from c in db.CarModels select c;
            foreach (var item in models)
            {
                var ordersItem = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.CarModelId == item.Id);
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
                title = carModelTitle,
                date = carDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }

        private String GetOrderCarDataByType(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var types = from c in db.CarTypes select c;
            foreach (var item in types)
            {
                var ordersItem = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.CarTypeId == item.Id);
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
                title = carTypeTitle,
                date = carDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);

        }

        private String GetOrderCarDataByAC(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var ordersItem = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasAirConditioner == true);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Has AC", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Has AC", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasAirConditioner == false);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("No AC", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("No AC", ordersItem.Sum(o => o.TotalPrice)));
            }
            var obj = new
            {
                title = carACTitle,
                date = carDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }

        private String GetOrderCarDataByDriver(IQueryable<Models.Order> orders)
        {
            if (!orders.Any())
            {
                return null;
            }
            List<DataPoint> dataPoints = new List<DataPoint>();
            var ordersItem = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasDriver == true);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("Has Driver", 0));

            }
            else
            {
                dataPoints.Add(new DataPoint("Has Driver", ordersItem.Sum(o => o.TotalPrice)));
            }
            ordersItem = orders.Where(o => o.OrderCars.FirstOrDefault().CarSchedule.Car.HasDriver == false);
            if (ordersItem == null || ordersItem.Count() == 0)
            {
                dataPoints.Add(new DataPoint("No Driver", 0));
            }
            else
            {
                dataPoints.Add(new DataPoint("No Driver", ordersItem.Sum(o => o.TotalPrice)));
            }
            var obj = new
            {
                title = carDriverTitle,
                date = carDateRange,
                data = dataPoints
            };
            return JsonConvert.SerializeObject(obj);
        }
    }
}