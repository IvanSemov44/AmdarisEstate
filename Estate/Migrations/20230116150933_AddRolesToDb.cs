using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class AddRolesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
