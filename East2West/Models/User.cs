using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    [Table("Users")]
    public class User : Microsoft.AspNet.Identity.EntityFramework.IdentityUser
    {
        [StringLength(50)]
        [Required]
        public String FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public String LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Address { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Thumbnail { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public String Description { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}