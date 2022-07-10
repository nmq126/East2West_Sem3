using East2West.Data;
using East2West.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class FeedbackController : Controller
    {
        private DBContext db = new DBContext();
        // GET: Feedback
        public JsonResult CreateFeedback(string orderId, double rating, string title, string content)
        {
            String id;

            if (db.Orders.Find(orderId) == null)
            {
                return Json(new
                {
                    message = "Order not found.",
                    status = -1
                });
            }
            do
            {
                id = String.Concat("FB_", Guid.NewGuid().ToString("N").Substring(0, 5));
            } while (db.Feedbacks.FirstOrDefault(c => c.Id == id) != null);
            var feedback = new Feedback() {
                Id = id,
                OrderId = orderId,
                Rating = rating,
                Title = title,
                Content = content
            };
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            return Json(new
            {
                message = "Action success.",
                status = 1
            });
        }
    }
}