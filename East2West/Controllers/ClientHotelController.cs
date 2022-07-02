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
    public class ClientHotelController : Controller
    {
        private DBContext db = new DBContext();
        // GET: ClientHotel

        public ActionResult GetListHotel(string sortType, string keyword, string price_range, string locationId, string rating, int? page)
        {
            var hotels = from h in db.Hotels select h;
            ViewBag.LocationList = from l in db.Locations select l;
            ViewBag.SortType = sortType;
            ViewBag.Keyword = keyword;
            ViewBag.PriceRange = price_range;
            ViewBag.Rating = rating;
            ViewBag.LocationId = locationId;
            ViewBag.Page = page;
            int pageNumber = (page ?? 1);
            int pageSize = 5;
            if (!String.IsNullOrEmpty(keyword))
            {
               hotels = hotels.Where(h=>h.Name.Contains(keyword) || h.Description.Contains(keyword)|| h.Detail.Contains(keyword) || h.Address.Contains(keyword));
            }
            if (!String.IsNullOrEmpty(locationId))
            {
                hotels = hotels.Where(h => h.LocationId == locationId);
            }
            switch (rating)
            {
                case "1":
                    hotels = hotels.Where(t => t.Rating == 1);
                    break;

                case "2":
                    hotels = hotels.Where(t => t.Rating == 2);
                    break;

                case "3":
                    hotels = hotels.Where(t => t.Rating == 3);
                    break;

                case "4":
                    hotels = hotels.Where(t => t.Rating == 4);
                    break;

                case "5":
                    hotels = hotels.Where(t => t.Rating == 5);
                    break;
            }
            switch (price_range)
            {
                case "all":
                    break;

                case "lt100":
                    hotels = hotels.Where(t => t.Price <= 100);
                    break;

                case "100to500":
                    hotels = hotels.Where(t => t.Price > 100 && t.Price <= 500);
                    break;

                case "500t1000":
                    hotels = hotels.Where(t => t.Price > 500 && t.Price <= 1000);
                    break;

                case "gt1000":
                    hotels = hotels.Where(t => t.Price > 1000);
                    break;

                default:
                    break;
            }

            switch (sortType)
            {
                case "createdAt_asc":
                    hotels = hotels.OrderBy(s => s.CreatedAt);
                    break;

                case "createdAt_desc":
                    hotels = hotels.OrderByDescending(s => s.CreatedAt);
                    break;
                case "rating_asc":
                    hotels = hotels.OrderBy(t => t.Rating);
                    break;

                case "rating_desc":
                    hotels = hotels.OrderByDescending(t => t.Rating);
                    break;

                default:
                    hotels = hotels.OrderBy(s => s.CreatedAt);
                    break;
            }
            return View(hotels.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Details(string id)
        {
            ViewBag.UserId = Convert.ToString(System.Web.HttpContext.Current.User.Identity.GetUserId());
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Include(x=>x.Location).FirstOrDefault(x=> x.Id == id);
            if(hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.Location = hotel.Location;
            return View(hotel);
        }
    }
}