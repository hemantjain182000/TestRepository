using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CySchool.Models
{
    public class SchoolContext : DbContext
    {
        #region constructor to initialise

        public SchoolContext()
        {
            Database.SetInitializer<SchoolContext>(null);
        }

        #endregion

        #region Member Function

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        #endregion
    }
}