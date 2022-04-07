using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PragueParkingDataAccess.Migrations
{
    public partial class InitialV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Garages_ParkingGarageId",
                table: "ParkingSpots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_ParkingGarageId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "ParkingGarageId",
                table: "ParkingSpots");

            migrationBuilder.AddColumn<int>(
                name: "GarageId",
                table: "ParkingSpots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_GarageId",
                table: "ParkingSpots",
                column: "GarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Garages_GarageId",
                table: "ParkingSpots",
                column: "GarageId",
                principalTable: "Garages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSpots_Garages_GarageId",
                table: "ParkingSpots");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSpots_GarageId",
                table: "ParkingSpots");

            migrationBuilder.DropColumn(
                name: "GarageId",
                table: "ParkingSpots");

            migrationBuilder.AddColumn<int>(
                name: "ParkingGarageId",
                table: "ParkingSpots",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpots_ParkingGarageId",
                table: "ParkingSpots",
                column: "ParkingGarageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSpots_Garages_ParkingGarageId",
                table: "ParkingSpots",
                column: "ParkingGarageId",
                principalTable: "Garages",
                principalColumn: "Id");
        }
    }
}
