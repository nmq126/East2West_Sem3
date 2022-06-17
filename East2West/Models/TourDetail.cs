using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("TourDetails")]
    public class TourDetail
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String TourId { get; set; }

        [Required]
        public DateTime DepartureDay { get; set; }

        [Required]
        public int AvailableSeat { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public int Discount { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public virtual Tour Tour { get; set; }
    }
}