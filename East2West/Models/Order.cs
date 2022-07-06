using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String UserId { get; set; }

        [Required]
        public Double TotalPrice { get; set; }

        [Required]
        public int Type { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public virtual Refund Refund { get; set; }
        public virtual User User { get; set; }

        public ICollection<OrderCar> OrderCars { get; set; }
        public ICollection<OrderTour> OrderTours { get; set; }
    }
}