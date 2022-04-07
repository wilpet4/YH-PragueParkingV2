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
    [Migration("20220329062644_Initial")]
    partial class Initial
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
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("Garages");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingSpot", b =>
                {
                    b.Property<int>("ParkingSpotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ParkingSpotId"), 1L, 1);

                    b.Property<int?>("ParkingGarageId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("ParkingSpotId");

                    b.HasIndex("ParkingGarageId");

                    b.ToTable("ParkingSpots");
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
                    b.HasOne("PragueParkingDataAccess.ParkingGarage", null)
                        .WithMany("Vehicles")
                        .HasForeignKey("ParkingGarageId");
                });

            modelBuilder.Entity("PragueParkingDataAccess.Vehicle", b =>
                {
                    b.HasOne("PragueParkingDataAccess.ParkingSpot", "ParkingSpot")
                        .WithMany("Vehicles")
                        .HasForeignKey("ParkingSpotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpot");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingGarage", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingSpot", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
