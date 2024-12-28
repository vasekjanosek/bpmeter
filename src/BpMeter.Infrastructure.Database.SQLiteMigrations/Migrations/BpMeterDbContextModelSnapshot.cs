﻿// <auto-generated />
using System;
using BpMeter.Infrastructure.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BpMeter.Infrastructure.Database.SQLiteMigrations.Migrations
{
    [DbContext(typeof(BpMeterDbContext))]
    partial class BpMeterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0");

            modelBuilder.Entity("BpMeter.Infrastructure.Database.Entites.BloodPressureEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Commentary")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Diastolic")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HeartRate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Palpitation")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PartOfTheDay")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Systolic")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BloodPressures");
                });

            modelBuilder.Entity("BpMeter.Infrastructure.Database.Entites.BodyWeightEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Commentary")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("WeightInKg")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("BodyWeights");
                });

            modelBuilder.Entity("BpMeter.Infrastructure.Database.Entites.PersonalInformationEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HeightInCm")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PersonalInformation");
                });
#pragma warning restore 612, 618
        }
    }
}
