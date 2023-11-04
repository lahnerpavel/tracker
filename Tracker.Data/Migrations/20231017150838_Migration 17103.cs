using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration17103 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 17, 8, 38, 241, DateTimeKind.Local).AddTicks(7491));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 17, 8, 38, 241, DateTimeKind.Local).AddTicks(7523));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 12, 46, 54, 939, DateTimeKind.Local).AddTicks(8272));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 10, 17, 12, 46, 54, 939, DateTimeKind.Local).AddTicks(8308));
        }
    }
}
