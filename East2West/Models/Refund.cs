using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class Refund
    {
        public String Id { get; set; }
        public int Percent { get; set; }
        public Double TotalPrice { get; set; }
    }
}