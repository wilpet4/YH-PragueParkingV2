using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PragueParkingDataAccess.Migrations
{
    public partial class InitialSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Garages_GarageId",
                table: "ParkingSpots");

            migrationBuilder.RenameColumn(
                name: "GarageId",
                table: "ParkingSpots",
                newName: "ParkingGarageId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSpots_GarageId",
                table: "ParkingSpots",
                newName: "IX_ParkingSpots_ParkingGarageId");

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
                    { 32, 1, 4 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Garages_ParkingGarageId",
                table: "ParkingSpots",
                column: "ParkingGarageId",
                principalTable: "Garages",
                principalColumn: "GarageId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Garages_ParkingGarageId",
                table: "ParkingSpots");

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ParkingSpots",
                keyColumn: "ParkingSpotId",
                keyValue: 16);

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

            migrationBuilder.DeleteData(
                table: "Garages",
                keyColumn: "GarageId",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "ParkingGarageId",
                table: "ParkingSpots",
                newName: "GarageId");

            migrationBuilder.RenameIndex(
                name: "IX_ParkingSpots_ParkingGarageId",
                table: "ParkingSpots",
                newName: "IX_ParkingSpots_GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Garages_GarageId",
                table: "ParkingSpots",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "GarageId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
