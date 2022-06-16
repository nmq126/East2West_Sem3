using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class Car
    {
        public String Id { get; set; }
        public String CarModelId { get; set; }
        public String CarTypeId { get; set; }
        public String LocationId { get; set; }
        public String ThumbnailId { get; set; }
        public String LisencePlate { get; set; }
        public Boolean HasAirConditioner { get; set; }
        public int SeatCapacity { get; set; }
        public Double PricePerDay { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}