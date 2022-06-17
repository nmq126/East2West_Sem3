using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String TourId { get; set; }

        [StringLength(50)]
        [Required]
        public String CarId { get; set; }

        [Required]
        public Double Rating { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        [ForeignKey("TourId")]
        public virtual Tour Tour { get; set; }

        [ForeignKey("CarId")]
        public virtual Car Car { get; set; }
    }
}