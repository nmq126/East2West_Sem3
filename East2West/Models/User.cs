using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class User
    {
        public String Id { get; set; }
        public String UserName { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public String Thumbnail { get; set; }
        public String Description { get; set; }
        public String PasswordHash { get; set; }
        public String PhoneNumber { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}