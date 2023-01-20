using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class ConnectUserWithEstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "26df286c-72e0-40bf-a109-0c7bae0b8781");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ddc646d5-9a0a-40ab-915a-9efe0decd7c2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9043158-9c12-419f-a68c-392374a7f1b7");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "26df286c-72e0-40bf-a109-0c7bae0b8781", "05a6c2c0-0a0e-4b6b-a0cf-cb26594c8a86", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ddc646d5-9a0a-40ab-915a-9efe0decd7c2", "fc0332be-7469-427c-b293-8ca04a660224", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f9043158-9c12-419f-a68c-392374a7f1b7", "fdb7e9bb-a56a-47a6-9a1b-3abc8b3518ed", "Manager", "MANAGER" });
        }
    }
}
