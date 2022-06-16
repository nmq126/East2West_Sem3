using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace East2West.Models
{
    public class Feedback
    {
        public String ObjectId { get; set; }
        public String UserID { get; set; }
        public Double Rating { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}