using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Feedbacks")]
    public class Feedback
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String OrderId { get; set; }

        [Required]
        public Double Rating { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Content { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int Status { get; set; }
        public virtual Order Order { get; set; }
    }
}