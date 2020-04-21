using BigDataTeknoloji.Data.Entity.Entities;
using BigDataTeknoloji.Data.Entity.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Data.Entity.Data
{
   public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ApplicationLocationConfig());
  
        }
    }
}
