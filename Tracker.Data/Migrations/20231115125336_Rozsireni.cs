using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tracker.Data.Migrations
{
    public partial class Rozsireni : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "VehicleId", "Brand", "Model", "RegistrationNumber" },
                values: new object[,]
                {
                    { 3L, "Chevrolet", "Malibu", "DEF-456" },
                    { 4L, "Honda", "Civic", "GHI-789" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "VehicleId",
                keyValue: 4L);

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 1L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 15, 13, 49, 17, 513, DateTimeKind.Local).AddTicks(3504));

            migrationBuilder.UpdateData(
                table: "VehicleLocations",
                keyColumn: "LocationId",
                keyValue: 2L,
                column: "Timestamp",
                value: new DateTime(2023, 11, 15, 13, 49, 17, 513, DateTimeKind.Local).AddTicks(3541));
        }
    }
}
