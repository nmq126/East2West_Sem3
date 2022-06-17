using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class Hotel
    {
        public String Id { get; set; }
        public String LocaltionId { get; set; }
        public Double Rating { get; set; }
        public String Address { get; set; }
        public String Price { get; set; }
        public String Description { get; set; }
        public String Detail { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}