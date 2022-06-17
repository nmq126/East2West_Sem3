using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Description { get; set; }

        public ICollection<Car> Cars { get; set; }
        public ICollection<Hotel> Hotels { get; set; }
        public ICollection<Flight> FlightsDeparture { get; set; }
        public ICollection<Flight> FlightsDestination { get; set; }
        public ICollection<Tour> ToursDeparture { get; set; }
        public ICollection<Tour> ToursDestination { get; set; }
    }
}