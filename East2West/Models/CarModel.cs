using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("CarModels")]
    public class CarModel
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String CarBrandId { get; set; }

        [StringLength(50)]
        [Required]
        public String Name { get; set; }

        public ICollection<Car> Cars { get; set; }
        public CarBrand CarBrand { get; set; }
    }
}