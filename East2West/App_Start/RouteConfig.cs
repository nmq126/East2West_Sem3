using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace East2West
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            string adminUserUrl = "admin/users";
            string adminTourUrl = "admin/tours";
            string adminTourDetailUrl = "admin/tour-details";
            string adminCarUrl = "admin/cars";
            string adminCarScheduleUrl = "admin/car-schedules";
            string adminFlightUrl = "admin/flights";
            string adminHoteltUrl = "admin/hotels";

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

//ADMIN

            routes.MapRoute(
                name: "Dashboard",
                url: "admin/dashboard",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Tour Analysis",
                url: "admin/orders/tours",
                defaults: new { controller = "Orders", action = "GetTour", id = UrlParameter.Optional }
            );

            //USER admin
            routes.MapRoute(
                name: "User List",
                url: adminUserUrl,
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Edit",
                url: adminUserUrl + "/edit/{id}",
                defaults: new { controller = "Users", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Detail",
                url: adminUserUrl + "/{id}",
                defaults: new { controller = "Users", action = "Details", id = UrlParameter.Optional }
            );

            //TOUR
            routes.MapRoute(
                name: "Tour List",
                url: adminTourUrl,
                defaults: new { controller = "Tours", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tour Create",
                url: adminTourUrl + "/create",
                defaults: new { controller = "Tours", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Tour Edit",
                url: adminTourUrl + "/edit/{id}",
                defaults: new { controller = "Tours", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Tour Detail",
                url: adminTourUrl + "/{id}",
                defaults: new { controller = "Tours", action = "Details", id = UrlParameter.Optional }
            );

            //TOUR DETAIL
            routes.MapRoute(
                name: "Tour Detail List",
                url: adminTourDetailUrl,
                defaults: new { controller = "TourDetails", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "Tour Detail Create",
               url: adminTourDetailUrl + "/create",
               defaults: new { controller = "TourDetails", action = "Create", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "Tour Detail Edit",
               url: adminTourDetailUrl + "/edit/{id}",
               defaults: new { controller = "TourDetails", action = "Edit", id = UrlParameter.Optional }
           );
            routes.MapRoute(
                name: "Tour Detail's Detail",
                url: adminTourDetailUrl + "/{id}",
                defaults: new { controller = "TourDetails", action = "Details", id = UrlParameter.Optional }
            );
           
           

            //CAR
            routes.MapRoute(
                name: "Car List",
                url: adminCarUrl,
                defaults: new { controller = "Cars", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Car Create",
                url: adminCarUrl + "/create",
                defaults: new { controller = "Cars", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Car Edit",
                url: adminCarUrl + "/edit/{id}",
                defaults: new { controller = "Cars", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Car Detail",
                url: adminCarUrl + "/{id}",
                defaults: new { controller = "Cars", action = "Details", id = UrlParameter.Optional }
            );

            //CAR SCHEDULE
            routes.MapRoute(
                name: "Car Schedule List",
                url: adminCarScheduleUrl,
                defaults: new { controller = "CarSchedules", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Car Schedule Create",
                url: adminCarScheduleUrl + "/create",
                defaults: new { controller = "CarSchedules", action = "Create", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Car Schedule Edit",
                url: adminCarScheduleUrl + "/edit/{id}",
                defaults: new { controller = "CarSchedules", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Car Schedule Detail",
                url: adminCarScheduleUrl + "/{id}",
                defaults: new { controller = "CarSchedules", action = "Details", id = UrlParameter.Optional }
            );

            //FLIGHT
            routes.MapRoute(
                name: "Flight List",
                url: adminFlightUrl,
                defaults: new { controller = "Flights", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Flight Create",
                url: adminFlightUrl + "/create",
                defaults: new { controller = "Flights", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Flight Edit",
                url: adminFlightUrl + "/edit/{id}",
                defaults: new { controller = "Flights", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Flight Detail",
                url: adminFlightUrl + "/{id}",
                defaults: new { controller = "Flights", action = "Details", id = UrlParameter.Optional }
            );

            //HOTEL
            routes.MapRoute(
                name: "Hotel List",
                url: adminHoteltUrl,
                defaults: new { controller = "Hotels", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Hotel Create",
                url: adminHoteltUrl + "/create",
                defaults: new { controller = "Hotels", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Hotel Edit",
                url: adminHoteltUrl + "/edit/{id}",
                defaults: new { controller = "Hotels", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Hotel Detail",
                url: adminHoteltUrl + "/{id}",
                defaults: new { controller = "Hotels", action = "Details", id = UrlParameter.Optional }
            );

//KHONG DUOC XOA
            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
           );
        }
    }
}
