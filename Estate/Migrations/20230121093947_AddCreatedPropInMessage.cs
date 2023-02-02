using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class AddCreatedPropInMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Messages",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Messages");
        }
    }
}
