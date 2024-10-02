using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "Status", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 6, 15, 23, 23, 431, DateTimeKind.Local).AddTicks(2766), null, "Otomobil", true, null },
                    { 2, new DateTime(2024, 9, 6, 15, 23, 23, 431, DateTimeKind.Local).AddTicks(2779), null, "Arazi, SUV & Pickup ", true, null },
                    { 3, new DateTime(2024, 9, 6, 15, 23, 23, 431, DateTimeKind.Local).AddTicks(2780), null, "Motosiklet", true, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
