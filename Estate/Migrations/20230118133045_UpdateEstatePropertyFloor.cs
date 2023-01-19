using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class UpdateEstatePropertyFloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "251ec7f9-2b3e-48fd-a3bb-275b28b6f111");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7a4a4a4-3279-4803-ae9a-96eb71b45ac9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8c7c1ff-afc9-4cd2-88a9-93d31db20c14");

            migrationBuilder.RenameColumn(
                name: "Floоr",
                table: "Estates",
                newName: "Floor");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "Floor",
                table: "Estates",
                newName: "Floоr");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "251ec7f9-2b3e-48fd-a3bb-275b28b6f111", "38c6dcea-76ae-45df-a4db-1f5d5e321834", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c7a4a4a4-3279-4803-ae9a-96eb71b45ac9", "dc6f3ec8-b0e9-4e35-a145-608c5831b198", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8c7c1ff-afc9-4cd2-88a9-93d31db20c14", "9c5e1b9a-e3a4-4563-88b3-f9952411c522", "Manager", "MANAGER" });
        }
    }
}
