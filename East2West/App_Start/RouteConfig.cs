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
            //admin
            string adminUserUrl = "admin/users";
            string adminOrderUrl = "admin/orders";
            string adminRefundUrl = "admin/refunds";
            string adminTourUrl = "admin/tours";
            string adminTourDetailUrl = "admin/tour-details";
            string adminCarUrl = "admin/cars";
            string adminCarScheduleUrl = "admin/car-schedules";
            string adminFlightUrl = "admin/flights";
            string adminHoteltUrl = "admin/hotels";
            //client
            string clientUserUrl = "home/users";
            string clientCarUrl = "home/cars";
            string clientTourUrl = "home/tours";
            string clientHotelUrl = "home/hotels";
            string clientFlightUrl = "home/flights";
            string aboutUsUrl = "home/about-us";
            string contactUsUrl = "home/contact-us";
            string thankYouUrl = "home/thank-you";
            string error404Url = "home/page-404";

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //ADMIN

            routes.MapRoute(
                name: "Dashboard",
                url: "admin/dashboard",
                defaults: new { controller = "Dashboard", action = "Index", id = UrlParameter.Optional }
            );

            //ORDER
            routes.MapRoute(
                name: "Tour Analysis",
                url: adminOrderUrl + "/tours",
                defaults: new { controller = "Orders", action = "GetTour", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Car Analysis",
                url: adminOrderUrl + "/cars",
                defaults: new { controller = "Orders", action = "GetCar", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Order Detail",
                url: adminOrderUrl + "/{id}",
                defaults: new { controller = "Orders", action = "Details", id = UrlParameter.Optional }
            );

            //REFUND
            routes.MapRoute(
                name: "Refund list",
                url: adminRefundUrl,
                defaults: new { controller = "Refunds", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Refund Detail",
                url: adminOrderUrl + "/{id}",
                defaults: new { controller = "Refunds", action = "Details", id = UrlParameter.Optional }
            );

            //USER admin
            routes.MapRoute(
                name: "User List",
                url: adminUserUrl,
                defaults: new { controller = "Users", action = "Index", id = UrlParameter.Optional, page = UrlParameter.Optional }
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

            //CLIENT
            //User
            routes.MapRoute(
                name: "User Profile",
                url: clientUserUrl + "/profile/{id}",
                defaults: new { controller = "User", action = "ShowInformation", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "User Login",
                url: clientUserUrl + "/login",
                defaults: new { controller = "User", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "User Register",
                url: clientUserUrl + "/register",
                defaults: new { controller = "User", action = "Register", id = UrlParameter.Optional }
            );
            //Tour
            routes.MapRoute(
                name: "Client Tour List",
                url: clientTourUrl,
                defaults: new { controller = "ClientTour", action = "GetListTour", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Client Tour Detail",
                url: clientTourUrl + "/{id}",
                defaults: new { controller = "ClientTour", action = "Details", id = UrlParameter.Optional }
            );

            //Car
            routes.MapRoute(
                name: "Client Car List",
                url: clientCarUrl,
                defaults: new { controller = "ClientCar", action = "GetListCar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Client Car Detail",
                url: clientCarUrl + "/{id}",
                defaults: new { controller = "ClientCar", action = "Details", id = UrlParameter.Optional }
            );
            //Hotel
            routes.MapRoute(
                name: "Client Hotel List",
                url: clientHotelUrl,
                defaults: new { controller = "ClientHotel", action = "GetListHotel", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Client Hotel Detail",
                url: clientHotelUrl + "/{id}",
                defaults: new { controller = "ClientHotel", action = "Details", id = UrlParameter.Optional }
            );
            //Flight
            routes.MapRoute(
                name: "Client Flight List",
                url: clientFlightUrl,
                defaults: new { controller = "ClientFlight", action = "GetListFlight", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Client Flight Detail",
                url: clientFlightUrl + "/{id}",
                defaults: new { controller = "ClientFlight", action = "Details", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "About Us",
                url: aboutUsUrl,
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Contact Us",
                url: contactUsUrl,
                defaults: new { controller = "Home", action = "Contact", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Thank you",
                url: thankYouUrl,
                defaults: new { controller = "Home", action = "ThankYou", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "404",
                url: error404Url,
                defaults: new { controller = "Home", action = "Error404", id = UrlParameter.Optional }
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