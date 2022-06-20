using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Cars")]
    public class Car
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String CarModelId { get; set; }

        [StringLength(50)]
        [Required]
        public String CarTypeId { get; set; }

        [StringLength(50)]
        [Required]
        public String LocationId { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Thumbnail { get; set; }

        [StringLength(50)]
        [Required]
        public String LisencePlate { get; set; }

        [Required]
        public Boolean HasAirConditioner { get; set; }

        [Required]
        public int SeatCapacity { get; set; }

        [Required]
        public Double PricePerDay { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public ICollection<CarSchedule> CarSchedules { get; set; }
        public CarType CarType { get; set; }
        public CarModel CarModel { get; set; }
        public Location Location { get; set; }
    }
}