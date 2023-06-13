using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Layout.DBContext
{
    public class DbEnitityContext : DbContext
    {
      
            public DbEnitityContext()
                : base("name=DBSchoolEntity")
            {
            }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
    }