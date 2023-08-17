using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MonopolyTestTask.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pallets",
                columns: new[] { "Id", "Height", "Length", "Width" },
                values: new object[,]
                {
                    { 1, 40, 50, 40 },
                    { 2, 40, 50, 40 },
                    { 3, 40, 50, 40 },
                    { 4, 40, 50, 40 }
                });

            migrationBuilder.InsertData(
                table: "Boxes",
                columns: new[] { "Id", "ExperationDate", "Height", "Length", "PalletId", "ProductionDate", "Weight", "Width" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 4, new DateTime(2004, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 2, new DateTime(2025, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 8, 4, null, 10, 10 },
                    { 3, new DateTime(2010, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2, 3, null, 10, 10 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 12, 3, new DateTime(2020, 4, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 17 },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 5, 2, new DateTime(2019, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10, 2, new DateTime(2008, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 10 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 1, 1, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 10 },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 4, new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 7, 4, new DateTime(2018, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 8 },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 4, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 7, 1, new DateTime(2015, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 9, 3, new DateTime(2000, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 4, 1, new DateTime(2000, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 10 },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 2, new DateTime(2002, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 11 },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 5, 1, new DateTime(2001, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 12 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Boxes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Pallets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pallets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pallets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pallets",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
