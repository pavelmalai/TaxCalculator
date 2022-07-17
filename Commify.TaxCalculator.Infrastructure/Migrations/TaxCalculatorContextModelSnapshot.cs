﻿// <auto-generated />
using System;
using Commify.TaxCalculator.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Commify.TaxCalculator.Infrastructure.Migrations
{
    [DbContext(typeof(TaxCalculatorContext))]
    partial class TaxCalculatorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("Commify.TaxCalculator.Core.DataAccess.Models.TaxBand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SalaryLowerLimit")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SalaryUpperLimit")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TaxRate")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TaxBands");

                    b.HasData(
                        new
                        {
                            Id = new Guid("73eaa000-bd7c-4337-87b4-80c3b1c80ab4"),
                            Name = "TaxBandA",
                            SalaryLowerLimit = 0,
                            SalaryUpperLimit = 5000,
                            TaxRate = 0
                        },
                        new
                        {
                            Id = new Guid("4dff37d1-c1c5-4cbe-85b7-0f484578ce19"),
                            Name = "TaxBandB",
                            SalaryLowerLimit = 5000,
                            SalaryUpperLimit = 20000,
                            TaxRate = 20
                        },
                        new
                        {
                            Id = new Guid("162811d6-91ff-41be-9a5c-493d3ffca94b"),
                            Name = "TaxBandC",
                            SalaryLowerLimit = 20000,
                            TaxRate = 40
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
