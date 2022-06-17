using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace East2West.Data
{
    public class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }
    }
}