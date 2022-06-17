using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("OrderTours")]
    public class OrderTour
    {
        [Key]
        [Column(Order = 0)]
        public String OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public String TourDetailId { get; set; }

        [Required]
        public Double UnitPrice { get; set; }

        [Required]
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual TourDetail TourDetail { get; set; }
    }
}