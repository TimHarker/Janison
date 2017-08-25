using Janison.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Janison.Data
{
    public class JanisonContext : DbContext
    {
        public JanisonContext() : base("JanisonContext")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Module> Modules { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure default schema
            //modelBuilder.HasDefaultSchema("janison");

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}