using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class CreateTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Estates");

            migrationBuilder.AddColumn<Guid>(
                name: "EstateTypeId",
                table: "Estates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EstateTypes",
                columns: table => new
                {
                    EstateTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstateTypes", x => x.EstateTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estates_EstateTypeId",
                table: "Estates",
                column: "EstateTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_EstateTypes_EstateTypeId",
                table: "Estates",
                column: "EstateTypeId",
                principalTable: "EstateTypes",
                principalColumn: "EstateTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_EstateTypes_EstateTypeId",
                table: "Estates");

            migrationBuilder.DropTable(
                name: "EstateTypes");

            migrationBuilder.DropIndex(
                name: "IX_Estates_EstateTypeId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "EstateTypeId",
                table: "Estates");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Estates",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
