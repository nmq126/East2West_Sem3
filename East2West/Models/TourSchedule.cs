using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("TourSchedules")]
    public class TourSchedule
    {
        [Key]
        [StringLength(50)]
        public String Id { get; set; }

        [StringLength(50)]
        [Required]
        public String TourId { get; set; }

        [Required]
        public int ScheduleOrder { get; set; }

        [StringLength(50)]
        [Required]
        public String Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Detail { get; set; }

        public virtual Tour Tour { get; set; }
    }
}