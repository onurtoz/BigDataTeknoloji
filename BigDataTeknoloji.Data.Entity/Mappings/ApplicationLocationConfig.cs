using BigDataTeknoloji.Data.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BigDataTeknoloji.Data.Entity.Mappings
{
    public class ApplicationLocationConfig : IEntityTypeConfiguration<Location>
    {

        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Created).IsRequired();
            builder.Property(x => x.Modified).IsRequired();
            builder.Property(x => x.LocationName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.Latitude).IsRequired();
            builder.Property(x => x.TodaysTempature).IsRequired();
            builder.Property(x => x.HighestTempature).IsRequired();
            builder.Property(x => x.LowestTempature).IsRequired();

            builder.ToTable("Locations");
        }
    }
}
