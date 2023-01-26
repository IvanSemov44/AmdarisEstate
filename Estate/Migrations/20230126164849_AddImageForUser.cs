using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class AddImageForUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_UserId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "078b78c1-3743-4ab0-b99d-d4050ae77473");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37b80c3d-8faf-4ebf-91df-75be19b406aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3ba3cac4-9816-4548-a307-63f67ca5f0fd");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "Images");

            migrationBuilder.CreateTable(
                name: "OwnerImages",
                columns: table => new
                {
                    OwnerImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultImg = table.Column<bool>(type: "bit", nullable: true),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerImages", x => x.OwnerImageId);
                    table.ForeignKey(
                        name: "FK_OwnerImages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "854abba1-58cb-4a1b-87a5-8297d8d78f3a", "9f40e6af-e2b1-4c9b-82cd-865924734d30", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8bc610b9-2bb7-4b83-a0e0-8c349bb3de74", "17b5c4d1-f294-4fe9-8d11-cb24a2da843d", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c331874b-5390-4796-af65-61f553b6ac21", "528aa44f-f4c8-494a-9951-0310bd9bbc50", "Manager", "MANAGER" });

            migrationBuilder.CreateIndex(
                name: "IX_OwnerImages_UserId",
                table: "OwnerImages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnerImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "854abba1-58cb-4a1b-87a5-8297d8d78f3a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc610b9-2bb7-4b83-a0e0-8c349bb3de74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c331874b-5390-4796-af65-61f553b6ac21");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ownerId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "078b78c1-3743-4ab0-b99d-d4050ae77473", "44665320-362a-4ac7-b77e-f401e558d53f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37b80c3d-8faf-4ebf-91df-75be19b406aa", "e7731988-1cd6-465d-9b3e-f6e2e54091cf", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3ba3cac4-9816-4548-a307-63f67ca5f0fd", "eeb469c5-4d09-43c2-a96d-b42f91d3f74e", "Employee", "EMPLOYEE" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_UserId",
                table: "Images",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
