using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Four : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 12, 4, 15, 43, 39, 739, DateTimeKind.Utc).AddTicks(4129));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 12, 4, 15, 43, 39, 739, DateTimeKind.Utc).AddTicks(4132));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
