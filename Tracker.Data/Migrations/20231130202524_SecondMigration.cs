using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 30, 20, 25, 24, 326, DateTimeKind.Utc).AddTicks(1601));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 30, 20, 25, 24, 326, DateTimeKind.Utc).AddTicks(1604));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 30, 21, 16, 53, 231, DateTimeKind.Local).AddTicks(9731));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 30, 21, 16, 53, 231, DateTimeKind.Local).AddTicks(9764));
        }
    }
}
