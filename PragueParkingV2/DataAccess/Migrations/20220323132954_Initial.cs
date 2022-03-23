using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppDataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.ParkingSpotId);
                });

            migrationBuilder.CreateTable(
                name: "Garages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParkingSpotsParkingSpotId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Garages_ParkingSpots_ParkingSpotsParkingSpotId",
                        column: x => x.ParkingSpotsParkingSpotId,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotId");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<byte>(type: "tinyint", nullable: false),
                    Registration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Arrival = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicle_ParkingSpots_ParkingSpotId",
                        column: x => x.ParkingSpotId,
                        principalTable: "ParkingSpots",
                        principalColumn: "ParkingSpotId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Garages_ParkingSpotsParkingSpotId",
                table: "Garages",
                column: "ParkingSpotsParkingSpotId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Garages");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpots");
        }
    }
}
