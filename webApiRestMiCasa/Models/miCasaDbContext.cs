using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webApiRestMiCasa.Models
{
    public class miCasaDbContext:DbContext
    {
        public miCasaDbContext(): base("name=Model1")
        {

        }
        public DbSet<Casas> Casas { get; set; }
        public DbSet<Dueños> Dueños { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<int>().Where(x => x.Name.StartsWith("id")).Configure(x => x.IsKey());
            modelBuilder.Entity<Casas>().HasRequired(p => p.Dueños);
            base.OnModelCreating(modelBuilder);
        }
    }
}