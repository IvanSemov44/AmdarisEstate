using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IvanRealEstate.Migrations
{
    public partial class UpdateImageForCompany2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Estates_EstateId",
                table: "Images");

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

            migrationBuilder.DropColumn(
                name: "CompanyImageId",
                table: "Images");

            migrationBuilder.AlterColumn<Guid>(
                name: "EstateId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "60e20a03-1ff3-4e16-9187-489350536f41", "0a925b74-887f-4c23-9be0-978a8b7c04a7", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "728f89e2-d5eb-4eba-a6c3-a6ac0b26d33b", "c83e0e7c-a92e-4022-828d-f62cf497d486", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a78b7778-f116-4bc8-b6fa-5b44f3b4ed7c", "43a62285-3fb6-481b-b994-92ce92fb29ac", "Employee", "EMPLOYEE" });

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Estates_EstateId",
                table: "Images",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "EstateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Estates_EstateId",
                table: "Images");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60e20a03-1ff3-4e16-9187-489350536f41");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "728f89e2-d5eb-4eba-a6c3-a6ac0b26d33b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a78b7778-f116-4bc8-b6fa-5b44f3b4ed7c");

            migrationBuilder.AlterColumn<Guid>(
                name: "EstateId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyImageId",
                table: "Images",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Estates_EstateId",
                table: "Images",
                column: "EstateId",
                principalTable: "Estates",
                principalColumn: "EstateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
