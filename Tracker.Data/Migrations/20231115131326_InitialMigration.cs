using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 15, 14, 13, 26, 188, DateTimeKind.Local).AddTicks(654));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 15, 14, 13, 26, 188, DateTimeKind.Local).AddTicks(684));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 15, 13, 53, 36, 335, DateTimeKind.Local).AddTicks(5299));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 15, 13, 53, 36, 335, DateTimeKind.Local).AddTicks(5336));
        }
    }
}
