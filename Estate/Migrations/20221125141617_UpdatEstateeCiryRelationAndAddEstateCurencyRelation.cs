using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class UpdatEstateeCiryRelationAndAddEstateCurencyRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstateCity");

            migrationBuilder.AddColumn<Guid>(
                name: "CityId",
                table: "Estates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CurencyId",
                table: "Estates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Curencies",
                columns: table => new
                {
                    CurencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurencyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curencies", x => x.CurencyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_CityId",
                table: "Estates",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_CurencyId",
                table: "Estates",
                column: "CurencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Cities_CityId",
                table: "Estates",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_Curencies_CurencyId",
                table: "Estates",
                column: "CurencyId",
                principalTable: "Curencies",
                principalColumn: "CurencyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Cities_CityId",
                table: "Estates");

            migrationBuilder.DropForeignKey(
                name: "FK_Estates_Curencies_CurencyId",
                table: "Estates");

            migrationBuilder.DropTable(
                name: "Curencies");

            migrationBuilder.DropIndex(
                name: "IX_Estates_CityId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_CurencyId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "CurencyId",
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
    }
}
