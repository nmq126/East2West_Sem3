using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class TourCategory
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }
        [StringLength(50)]
        [Required]
        public String Name { get; set; }
        public ICollection<Tour> Tours { get; set; }
    }
}