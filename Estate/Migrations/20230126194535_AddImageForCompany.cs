using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class AddImageForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
