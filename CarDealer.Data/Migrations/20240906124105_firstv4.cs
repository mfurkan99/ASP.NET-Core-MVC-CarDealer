using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarDealer.Data.Migrations
{
    /// <inheritdoc />
    public partial class firstv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Brand", "CategoryId", "Color", "CreatedDate", "DeletedDate", "ImageUrl", "Kilometer", "Model", "Name", "Price", "Status", "UpdatedDate", "Year" },
                values: new object[,]
                {
                    { 1, "Mercedes-Benz", 1, "Siyah", new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(1215), null, "", 45000, "E220d", null, 3800000, true, null, 2018 },
                    { 2, "Land Rover", 2, "White", new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(1229), null, "", 65000, "Range Rover", null, 10000000, true, null, 2020 },
                    { 3, "Audi", 2, "Siyah", new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(1231), null, "", 187000, "Q7", null, 4000000, true, null, 2018 },
                    { 4, "Volvo", 1, "Blue", new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(1232), null, "", 38000, "S90", null, 3500000, true, null, 2022 },
                    { 5, "BMW", 1, "Gray", new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(1234), null, "", 50000, "5.20i", null, 2800000, true, null, 2022 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 15, 41, 5, 668, DateTimeKind.Local).AddTicks(2195));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 15, 23, 23, 431, DateTimeKind.Local).AddTicks(2766));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 15, 23, 23, 431, DateTimeKind.Local).AddTicks(2779));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2024, 9, 6, 15, 23, 23, 431, DateTimeKind.Local).AddTicks(2780));
        }
    }
}
