using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Flights")]
    public class Flight
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [Required]
        public Boolean IsRoundTicket { get; set; }

        [StringLength(50)]
        [Required]
        public String DepartureId { get; set; }

        [StringLength(50)]
        [Required]
        public String DestinationId { get; set; }

        [Required]
        public DateTime DepartureAt { get; set; }

        [StringLength(50)]
        [Required]
        public String Duration { get; set; }

        [Required]
        public Double Price { get; set; }

        [Required]
        public DateTime ReturnAt { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Detail { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public Location LocationDeparture { get; set; }
        public Location LocationDestination { get; set; }
    }
}