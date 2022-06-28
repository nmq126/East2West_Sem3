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
    public class ClientHotelController : Controller
    {
        private DBContext db = new DBContext();
        // GET: ClientHotel
    
        public ActionResult GetListHotel()
        {

            var hotel = db.Hotels.Include(x => x.Location).OrderByDescending(x => x.CreatedAt);
            return View(hotel.ToList());
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
            return View();
        }
    }
}