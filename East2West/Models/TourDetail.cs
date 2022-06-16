using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class TourDetail
    {
        public String Id { get; set; }
        public String TourId { get; set; }
        public DateTime DepartureDay { get; set; }
        public int AvailableSeat { get; set; }
        public Double Price { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}