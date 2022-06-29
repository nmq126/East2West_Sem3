using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Refunds")]
    public class Refund
    {
        [Key]
        [StringLength(50)]
        [ForeignKey("Order")]
        public String Id { get; set; }

        [Required]
        public int Percent { get; set; }

        [Required]
        public Double TotalPrice { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
 
        public virtual Order Order { get; set; }
    }
}