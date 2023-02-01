using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class UpdateImageForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyImages_Companies_CompanyId",
                table: "CompanyImages");

            migrationBuilder.DropIndex(
                name: "IX_CompanyImages_CompanyId",
                table: "CompanyImages");

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

            migrationBuilder.RenameColumn(
                name: "ImageCompanyId",
                table: "Images",
                newName: "CompanyImageId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "23e961ee-de20-4a28-93a2-7cc60a7e9353", "d1c9b2b0-b3c6-4cea-bb2c-f09e0e892c9a", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "51ce9213-98d6-4139-b39b-df12a3064c59", "95417204-eb08-4c92-9d12-01600df69d48", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a10ddeeb-6a65-4583-982e-7d265a840729", "8c9d7edd-9027-430f-9457-e9e1dacc84bc", "Manager", "MANAGER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "23e961ee-de20-4a28-93a2-7cc60a7e9353");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51ce9213-98d6-4139-b39b-df12a3064c59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a10ddeeb-6a65-4583-982e-7d265a840729");

            migrationBuilder.RenameColumn(
                name: "CompanyImageId",
                table: "Images",
                newName: "ImageCompanyId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyImages_Companies_CompanyId",
                table: "CompanyImages",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
