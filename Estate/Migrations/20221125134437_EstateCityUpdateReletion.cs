using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class EstateCityUpdateReletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Cities_CityId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_CityId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Estates");

            migrationBuilder.CreateTable(
                name: "EstateCity",
                columns: table => new
                {
                    EstateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateCity", x => new { x.EstateId, x.CityId });
                    table.ForeignKey(
                        name: "FK_EstateCity_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstateCity_Estates_EstateId",
                        column: x => x.EstateId,
                        principalTable: "Estates",
                        principalColumn: "EstateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstateCity_CityId",
                table: "EstateCity",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateCity");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Estates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Estates",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_CityId",
                table: "Estates",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Cities_CityId",
                table: "Estates",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId");
        }
    }
}
