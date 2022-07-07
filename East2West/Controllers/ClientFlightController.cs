using East2West.Data;
using East2West.Models;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class ClientFlightController : Controller
    {
        private DBContext db = new DBContext();
        // GET: ClientHotel

        public ActionResult GetListFlight(string sortType, int? page, string destinationId, string departureId, int? status, string keyword, string price_range, DateTime? from_date, DateTime? to_date)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            ViewBag.SortType = sortType;
            ViewBag.Status = status;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            ViewBag.PriceRange = price_range;
            ViewBag.Keyword = keyword;
            ViewBag.FromDate = from_date;
            ViewBag.ToDate = to_date;

            var flights = db.Flights.ToList();
            var locations = db.Locations.ToList();
            ViewBag.LocationList = db.Locations.ToList();


            flights = (status > 0) ? flights.Where(M => M.Status == status).ToList() : flights.ToList();

            if (!String.IsNullOrEmpty(destinationId))
            {
                flights = flights.Where(f => f.DestinationId == destinationId).ToList();
            }
            if (!String.IsNullOrEmpty(departureId))
            {
                flights = flights.Where(f => f.DepartureId == departureId).ToList();
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                flights = flights.Where(f => f.LocationDestination.Name.ToLower().Contains(keyword.ToLower()) || f.LocationDeparture.Name.ToLower().Contains(keyword.ToLower())).ToList();
            }
            if (from_date != null)
            {
                flights = flights.Where(f => f.DepartureAt >= from_date).ToList();
            }
            if (to_date != null)
            {
                flights = flights.Where(f => f.ReturnAt <= to_date).ToList();
            }

            switch (price_range)
            {
                case "all":
                    break;

                case "lt100":
                    flights = flights.Where(t => t.Price <= 100).ToList();
                    break;

                case "100to500":
                    flights = flights.Where(t => t.Price > 100 && t.Price <= 500).ToList();
                    break;

                case "500t1000":
                    flights = flights.Where(t => t.Price > 500 && t.Price <= 1000).ToList();
                    break;

                case "gt1000":
                    flights = flights.Where(t => t.Price > 1000).ToList();
                    break;

                default:
                    break;
            }

            switch (sortType)
            {
                case "createdAt_asc":
                    flights = flights.OrderBy(s => s.CreatedAt).ToList();
                    break;
                case "createdAt_desc":
                    flights = flights.OrderByDescending(s => s.CreatedAt).ToList();
                    break;
                case "duration_asc":
                    flights = flights.OrderBy(t => t.Duration).ToList();
                    break;
                case "duration_desc":
                    flights = flights.OrderByDescending(t => t.Duration).ToList();
                    break;
                default:
                    flights = flights.OrderBy(s => s.CreatedAt).ToList();
                    break;
            }

            return View(flights.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Details(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var flights = db.Flights.ToList();
            var locations = db.Locations.ToList();
            Flight flight = db.Flights.Where(M => M.Id == id).FirstOrDefault();
            var id_departure = flight.DepartureId;
            var id_destination = flight.DestinationId;
            var name_departure = locations.Find(x => x.Id == id_departure).Name;
            var name_destination = locations.Find(x => x.Id == id_destination).Name;

            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.LocationDeparture = name_departure ?? "";
            ViewBag.LocationDestination = name_destination ?? "";
            return View(flight);
        }
    }
}