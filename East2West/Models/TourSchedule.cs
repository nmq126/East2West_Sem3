using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class TourSchedule
    {
        public String Id { get; set; }
        public String TourId { get; set; }
        public int ScheduleOrder { get; set; }
        public String Name { get; set; }
        public String Detail { get; set; }
    }
}