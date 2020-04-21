﻿// <auto-generated />
using System;
using BigDataTeknoloji.Data.Entity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BigDataTeknoloji.Data.Entity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200420075539_BigdataDB Schema")]
    partial class BigdataDBSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BigDataTeknoloji.Data.Entity.Entities.Location", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<double>("HighestTempature");

                    b.Property<double>("Latitude");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("Longitude");

                    b.Property<double>("LowestTempature");

                    b.Property<DateTime>("Modified");

                    b.Property<double>("TodaysTempature");

                    b.HasKey("ID");

                    b.ToTable("Locations");
                });
#pragma warning restore 612, 618
        }
    }
}