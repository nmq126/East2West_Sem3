using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class OrderCar
    {
        public String Id { get; set; }
        public String UserId { get; set; }
        public String RefundId { get; set; }
        public String TotalPrice { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}