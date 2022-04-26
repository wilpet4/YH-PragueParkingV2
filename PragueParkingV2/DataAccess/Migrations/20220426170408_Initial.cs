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
                name: "Garages",
                columns: table => new
                {
                    GarageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garages", x => x.GarageId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpots",
                columns: table => new
                {
                    ParkingSpotId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<int>(type: "int", nullable: false),
                    ParkingGarageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpots", x => x.ParkingSpotId);
                    table.ForeignKey(
                        name: "FK_ParkingSpots_Garages_ParkingGarageId",
                        column: x => x.ParkingGarageId,
                        principalTable: "Garages",
                        principalColumn: "GarageId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Garages",
                column: "GarageId",
                value: 1);

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "ParkingSpotId", "ParkingGarageId", "Size" },
                values: new object[,]
                {
                    { 1, 1, 4 },
                    { 2, 1, 4 },
                    { 3, 1, 4 },
                    { 4, 1, 4 },
                    { 5, 1, 4 },
                    { 6, 1, 4 },
                    { 7, 1, 4 },
                    { 8, 1, 4 },
                    { 9, 1, 4 },
                    { 10, 1, 4 },
                    { 11, 1, 4 },
                    { 12, 1, 4 },
                    { 13, 1, 4 },
                    { 14, 1, 4 },
                    { 15, 1, 4 },
                    { 16, 1, 4 },
                    { 17, 1, 4 },
                    { 18, 1, 4 },
                    { 19, 1, 4 },
                    { 20, 1, 4 },
                    { 21, 1, 4 },
                    { 22, 1, 4 },
                    { 23, 1, 4 },
                    { 24, 1, 4 },
                    { 25, 1, 4 },
                    { 26, 1, 4 },
                    { 27, 1, 4 },
                    { 28, 1, 4 },
                    { 29, 1, 4 },
                    { 30, 1, 4 },
                    { 31, 1, 4 },
                    { 32, 1, 4 },
                    { 33, 1, 4 },
                    { 34, 1, 4 },
                    { 35, 1, 4 },
                    { 36, 1, 4 },
                    { 37, 1, 4 },
                    { 38, 1, 4 },
                    { 39, 1, 4 },
                    { 40, 1, 4 },
                    { 41, 1, 4 },
                    { 42, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "ParkingSpotId", "ParkingGarageId", "Size" },
                values: new object[,]
                {
                    { 43, 1, 4 },
                    { 44, 1, 4 },
                    { 45, 1, 4 },
                    { 46, 1, 4 },
                    { 47, 1, 4 },
                    { 48, 1, 4 },
                    { 49, 1, 4 },
                    { 50, 1, 4 },
                    { 51, 1, 4 },
                    { 52, 1, 4 },
                    { 53, 1, 4 },
                    { 54, 1, 4 },
                    { 55, 1, 4 },
                    { 56, 1, 4 },
                    { 57, 1, 4 },
                    { 58, 1, 4 },
                    { 59, 1, 4 },
                    { 60, 1, 4 },
                    { 61, 1, 4 },
                    { 62, 1, 4 },
                    { 63, 1, 4 },
                    { 64, 1, 4 },
                    { 65, 1, 4 },
                    { 66, 1, 4 },
                    { 67, 1, 4 },
                    { 68, 1, 4 },
                    { 69, 1, 4 },
                    { 70, 1, 4 },
                    { 71, 1, 4 },
                    { 72, 1, 4 },
                    { 73, 1, 4 },
                    { 74, 1, 4 },
                    { 75, 1, 4 },
                    { 76, 1, 4 },
                    { 77, 1, 4 },
                    { 78, 1, 4 },
                    { 79, 1, 4 },
                    { 80, 1, 4 },
                    { 81, 1, 4 },
                    { 82, 1, 4 },
                    { 83, 1, 4 },
                    { 84, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "ParkingSpotId", "ParkingGarageId", "Size" },
                values: new object[,]
                {
                    { 85, 1, 4 },
                    { 86, 1, 4 },
                    { 87, 1, 4 },
                    { 88, 1, 4 },
                    { 89, 1, 4 },
                    { 90, 1, 4 },
                    { 91, 1, 4 },
                    { 92, 1, 4 },
                    { 93, 1, 4 },
                    { 94, 1, 4 },
                    { 95, 1, 4 },
                    { 96, 1, 4 },
                    { 97, 1, 4 },
                    { 98, 1, 4 },
                    { 99, 1, 4 },
                    { 100, 1, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ParkingGarageId",
                table: "ParkingSpots",
                column: "ParkingGarageId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_ParkingSpotId",
                table: "Vehicle",
                column: "ParkingSpotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "ParkingSpots");

            migrationBuilder.DropTable(
                name: "Garages");
        }
    }
}
