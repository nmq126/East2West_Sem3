using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class OrderTourDetail
    {
        public String UserId { get; set; }
        public String TourDetailId { get; set; }
        public Double UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}