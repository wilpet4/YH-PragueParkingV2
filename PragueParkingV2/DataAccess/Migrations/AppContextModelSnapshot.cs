﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PragueParkingDataAccess;

#nullable disable

namespace WpfAppDataAccess.Migrations
{
    [DbContext(typeof(AppContext))]
    partial class AppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("ParkingSpotsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpotsId");

                    b.ToTable("Garages");
                });

            modelBuilder.Entity("PragueParkingDataAccess.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("Id");

                    b.ToTable("ParkingSpots");
                });

            modelBuilder.Entity("PragueParkingDataAccess.Vehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParkingSpotsId")
                        .HasColumnType("int");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Size")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("ParkingSpotsId");

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

            modelBuilder.Entity("PragueParkingDataAccess.ParkingGarage", b =>
                {
                    b.HasOne("PragueParkingDataAccess.ParkingSpot", "ParkingSpots")
                        .WithMany()
                        .HasForeignKey("ParkingSpotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParkingSpots");
                });

            modelBuilder.Entity("PragueParkingDataAccess.Vehicle", b =>
                {
                    b.HasOne("PragueParkingDataAccess.ParkingSpot", "ParkingSpots")
                        .WithMany("Vehicles")
                        .HasForeignKey("ParkingSpotsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
