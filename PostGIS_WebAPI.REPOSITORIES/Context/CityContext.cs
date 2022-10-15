using Microsoft.EntityFrameworkCore;
using PostGIS_WebAPI.ENTITIES.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostGIS_WebAPI.REPOSITORIES.Context
{
    public class CityContext : DbContext
    {
        public CityContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("postgis");
            modelBuilder.HasDefaultSchema("public");
           
        }

        public DbSet<Building> Buildings { get; set; }
    }
}
