using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("OrderCar")]
    public class OrderCar
    {
        [Key]
        [Column(Order = 0)]
        public String UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        public String CarScheduleId { get; set; }

        [Required]
        public Double UnitPrice { get; set; }
    }
}