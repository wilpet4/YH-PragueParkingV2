// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PragueParkingDataAccess;

#nullable disable

namespace WpfAppDataAccess.Migrations
{
    [DbContext(typeof(ParkingContext))]
    [Migration("20220521200652_Initial")]
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
                    b.Property<int>("GarageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GarageId"), 1L, 1);

                    b.HasKey("GarageId");

                    b.ToTable("Garages");
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
                });

            modelBuilder.Entity("PragueParkingDataAccess.Receipt", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReceiptId"), 1L, 1);

                    b.Property<DateTime>("Arrival")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Departure")
                        .HasColumnType("datetime2");

                    b.Property<int>("ParkingSpotId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReceiptId");

                    b.ToTable("Receipts");
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
