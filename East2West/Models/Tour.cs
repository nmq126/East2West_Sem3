using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class Tour
    {
        public String Id { get; set; }
        public String DepartureId { get; set; }
        public String DestinationId { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Detail { get; set; }
        public String Thumbnail { get; set; }
        public Double Duration { get; set; }
        public Double Rating { get; set; }
        public String Policy { get; set; }
        public String SummarySchedule { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}