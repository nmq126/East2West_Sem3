using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public JsonResult CreateFeedback(string orderId, string rating, string title, string content)
        {
            return View();
        }
    }
}