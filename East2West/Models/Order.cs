using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String UserId { get; set; }

        [StringLength(50)]
        public String RefundId { get; set; }

        [Required]
        public String TotalPrice { get; set; }

        [Required]
        public int Type { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        [ForeignKey("RefundId")]
        public virtual Refund Refund { get; set; }

        public virtual User User { get; set; }
        public ICollection<OrderCar> OrderCars { get; set; }
        public ICollection<OrderTour> OrderTours { get; set; }
    }
}