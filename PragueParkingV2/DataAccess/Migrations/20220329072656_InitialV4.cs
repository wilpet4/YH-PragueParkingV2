using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WpfAppDataAccess.Migrations
{
    public partial class InitialV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Garages",
                newName: "GarageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GarageId",
                table: "Garages",
                newName: "Id");
        }
    }
}
