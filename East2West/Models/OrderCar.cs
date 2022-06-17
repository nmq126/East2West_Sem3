using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("OrderCars")]
    public class OrderCar
    {
        [Key]
        [Column(Order = 0)]
        public String OrderId { get; set; }

        [Key]
        [Column(Order = 1)]
        public String CarScheduleId { get; set; }

        [Required]
        public Double UnitPrice { get; set; }
        public virtual Order Order { get; set; }
        public virtual CarSchedule CarSchedule { get; set; }
    }
}