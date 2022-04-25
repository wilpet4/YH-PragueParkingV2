using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PragueParkingDataAccess.Migrations
{
    public partial class InitialSeeded2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 32);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingSpots",
                columns: new[] { "ParkingSpotId", "ParkingGarageId", "Size" },
                values: new object[,]
                {
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
                    { 32, 1, 4 }
                });
        }
    }
}
