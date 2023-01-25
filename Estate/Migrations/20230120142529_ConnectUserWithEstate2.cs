using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class ConnectUserWithEstate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f5bbefc-ff79-4ff7-9ba5-9bb68dd13eee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93ca2f4c-4d0d-4fef-9038-159a17444f0a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d06cb408-7553-4711-afaf-d318411e0257");

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "Estates",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Estates",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estates_UserId",
                table: "Estates",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estates_AspNetUsers_UserId",
                table: "Estates",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estates_AspNetUsers_UserId",
                table: "Estates");

            migrationBuilder.DropIndex(
                name: "IX_Estates_UserId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Estates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Estates");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f5bbefc-ff79-4ff7-9ba5-9bb68dd13eee", "a986a0ef-2056-405c-bc47-139dd32c97b5", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "93ca2f4c-4d0d-4fef-9038-159a17444f0a", "a71e12f4-8956-431c-ad2b-316f4cf5567f", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d06cb408-7553-4711-afaf-d318411e0257", "0b54d147-74c3-48f0-9185-3c7e27f3e9ff", "Admin", "ADMIN" });
        }
    }
}
