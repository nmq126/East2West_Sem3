using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Hotels")]
    public class Hotel
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Thumbnail { get; set; }

        [StringLength(50)]
        [Required]
        public String LocationId { get; set; }

        [Required]
        public Double Rating { get; set; }
        [Column(TypeName = "ntext")]
        [Required]
        public String Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Address { get; set; }

        [Required]
        public String Price { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Description { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Detail { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public Location Location { get; set; }
    }
}