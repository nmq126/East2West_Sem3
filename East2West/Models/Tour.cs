using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace East2West.Models
{
    [Table("Tours")]
    public class Tour
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String DepartureId { get; set; }

        [StringLength(50)]
        [Required]
        public String DestinationId { get; set; }

        [StringLength(50)]
        [Required]
        public String Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Description { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [AllowHtml]
        public String Detail { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Thumbnail { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public Double Rating { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        [AllowHtml]
        public String Policy { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String SummarySchedule { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public virtual Location LocationDeparture { get; set; }
        public virtual Location LocationDestination { get; set; }
        public ICollection<TourDetail> TourDetails { get; set; }
        public ICollection<TourSchedule> TourSchedules { get; set; }
    }
}