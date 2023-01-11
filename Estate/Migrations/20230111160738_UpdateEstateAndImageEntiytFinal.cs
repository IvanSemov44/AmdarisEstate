using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class UpdateEstateAndImageEntiytFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "defaultImg",
                table: "Images",
                newName: "DefaultImg");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "Estates",
                newName: "EstateArea");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DefaultImg",
                table: "Images",
                newName: "defaultImg");

            migrationBuilder.RenameColumn(
                name: "EstateArea",
                table: "Estates",
                newName: "Area");
        }
    }
}
