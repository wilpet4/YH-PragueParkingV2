﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PragueParkingDataAccess;

#nullable disable

namespace PragueParkingDataAccess.Migrations
{
    [DbContext(typeof(ParkingContext))]
    [Migration("20220425130041_InitialSeeded")]
    partial class InitialSeeded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PragueParkingDataAccess.ParkingGarage", b =>
                {
                    b.Property<int>("GarageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GarageId"), 1L, 1);

                    b.HasKey("GarageId");

                    b.ToTable("Garages");

                    b.HasData(
                        new
                        {
                            GarageId = 1
                        });
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingSpot", b =>
                {
                    b.Property<int>("ParkingSpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParkingSpotId"), 1L, 1);

                    b.Property<int>("ParkingGarageId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpotId");

                    b.HasIndex("ParkingGarageId");

                    b.ToTable("ParkingSpots");

                    b.HasData(
                        new
                        {
                            ParkingSpotId = 1,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 2,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 3,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 4,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 5,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 6,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 7,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 8,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 9,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 10,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 11,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 12,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 13,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 14,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 15,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 16,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 17,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 18,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 19,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 20,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 21,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 22,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 23,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 24,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 25,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 26,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 27,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 28,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 29,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 30,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 31,
                            ParkingGarageId = 1,
                            Size = 4
                        },
                        new
                        {
                            ParkingSpotId = 32,
                            ParkingGarageId = 1,
                            Size = 4
                        });
                });

            modelBuilder.Entity("PragueParkingDataAccess.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"), 1L, 1);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<string>("Registration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Size")
                        .HasColumnType("tinyint");

                    b.HasKey("VehicleId");

                    b.HasIndex("ParkingSpotId");

                    b.ToTable("Vehicle");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Vehicle");
                });

            modelBuilder.Entity("PragueParkingDataAccess.Car", b =>
                {
                    b.HasBaseType("PragueParkingDataAccess.Vehicle");

                    b.HasDiscriminator().HasValue("Car");
                });

            modelBuilder.Entity("PragueParkingDataAccess.MC", b =>
                {
                    b.HasBaseType("PragueParkingDataAccess.Vehicle");

                    b.HasDiscriminator().HasValue("MC");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingSpot", b =>
                {
                    b.HasOne("PragueParkingDataAccess.ParkingGarage", "Garage")
                        .WithMany("ParkingSpots")
                        .HasForeignKey("ParkingGarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Garage");
                });

            modelBuilder.Entity("PragueParkingDataAccess.Vehicle", b =>
                {
                    b.HasOne("PragueParkingDataAccess.ParkingSpot", "Parking")
                        .WithMany("Vehicles")
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parking");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingGarage", b =>
                {
                    b.Navigation("ParkingSpots");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingSpot", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}