using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class UpdateEstateAndImageEntiytSecond : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "defaultImg",
                table: "Images",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Area",
                table: "Estates",
                type: "float",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "defaultImg",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Estates");
        }
    }
}
