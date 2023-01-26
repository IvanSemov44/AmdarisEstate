using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class AddImageForCompany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08e7a276-8515-46aa-9f91-d1274a028727");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "464fc247-ca19-4c83-b7a5-adae9dd61049");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9eca8b43-7a65-4f63-8d1d-66806ffba3da");

            migrationBuilder.CreateTable(
                name: "CompanyImages",
                columns: table => new
                {
                    CompanyImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DefaultImg = table.Column<bool>(type: "bit", nullable: true),
                    CompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompnayId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyImages", x => x.CompanyImageId);
                    table.ForeignKey(
                        name: "FK_CompanyImages_AspNetUsers_CompnayId",
                        column: x => x.CompnayId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CompanyImages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "03d9f727-ddaf-4c11-8e82-1ca90a2f79ae", "5cee4f62-e7bb-4043-b87d-cc5ce224cb3b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "44a41444-0434-4faf-8f7c-2977f5d3d1db", "55a497f8-9a96-4ca0-932b-afd734c98a30", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4e647f86-b984-4212-8eed-86fbafec6ee4", "41438401-a281-4a96-9fed-7cb823cc5566", "Manager", "MANAGER" });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyImages_CompanyId",
                table: "CompanyImages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyImages_CompnayId",
                table: "CompanyImages",
                column: "CompnayId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyImages");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "03d9f727-ddaf-4c11-8e82-1ca90a2f79ae");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44a41444-0434-4faf-8f7c-2977f5d3d1db");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4e647f86-b984-4212-8eed-86fbafec6ee4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "08e7a276-8515-46aa-9f91-d1274a028727", "34c4a18e-2c3e-40f5-9e3b-619d266030dd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "464fc247-ca19-4c83-b7a5-adae9dd61049", "37345428-d01e-4508-9a9e-cb7c395406bf", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9eca8b43-7a65-4f63-8d1d-66806ffba3da", "481c22f7-67e9-4ed1-8e8e-59b0f1ed1ac0", "Employee", "EMPLOYEE" });
        }
    }
}
