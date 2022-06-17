using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class Flight
    {
        public String Id { get; set; }
        public int Type { get; set; }
        public String DepartureId { get; set; }
        public String DestinationId { get; set; }
        public DateTime DepartureAt { get; set; }
        public String Duration { get; set; }
        public Double Price { get; set; }
        public DateTime ComebackAt { get; set; }
        public String Detail { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}