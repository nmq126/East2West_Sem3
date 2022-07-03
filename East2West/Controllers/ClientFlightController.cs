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

        public ActionResult GetListFlight(string sortType, int? page, string destinationId, string departureId, int? status, double? from_price, double? to_price, string keyword)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            ViewBag.SortType = sortType;
            ViewBag.Status = status;
            ViewBag.DepartureId = departureId;
            ViewBag.DestinationId = destinationId;
            ViewBag.From_price = from_price;
            ViewBag.To_price = to_price;
            ViewBag.Keyword = keyword;

            var flights = db.Flights.ToList();
            var locations = db.Locations.ToList();
            ViewBag.LocationList = db.Locations.ToList();


            flights = (status > 0) ? flights.Where(M => M.Status == status).ToList() : flights.ToList();

            if (!String.IsNullOrEmpty(destinationId))
            {
                flights = flights.Where(f => f.DestinationId == destinationId).ToList();
            }
            if (!String.IsNullOrEmpty(destinationId))
            {
                flights = flights.Where(f => f.DepartureId == departureId).ToList();
            }
            if (from_price >=0)
            {
                flights = flights.Where(f => f.Price >= from_price).ToList();
            }
            if (to_price > 0)
            {
                flights = flights.Where(f => f.Price <= to_price).ToList();
            }
            if (!String.IsNullOrEmpty(keyword))
            {
                flights = flights.Where(f => f.LocationDestination.Name.ToLower().Contains(keyword.ToLower()) || f.LocationDeparture.Name.ToLower().Contains(keyword.ToLower())).ToList();
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