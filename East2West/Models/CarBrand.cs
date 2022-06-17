using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("CarBrands")]
    public class CarBrand
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String Name { get; set; }

        public ICollection<CarModel> CarModels { get; set; }
    }
}