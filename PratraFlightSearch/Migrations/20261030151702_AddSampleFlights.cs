using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PratraFlightSearch.Migrations
{
    /// <inheritdoc />
    public partial class AddSampleFlights : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AirlineName", "ArrivalTime", "DepartureTime", "Destination", "FlightNumber", "Price", "Source" },
                values: new object[,]
                {
                    { 1, "Air India", new DateTime(2026, 11, 15, 9, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 6, 0, 0, 0, DateTimeKind.Unspecified), "DXB", "AI101", 18000m, "MAA" },
                    { 2, "Emirates", new DateTime(2026, 11, 15, 11, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 8, 0, 0, 0, DateTimeKind.Unspecified), "DXB", "EK543", 22000m, "MAA" },
                    { 3, "IndiGo", new DateTime(2026, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "DXB", "6E205", 15000m, "MAA" },
                    { 4, "Air India", new DateTime(2026, 11, 15, 9, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), "DEL", "AI202", 8000m, "BLR" },
                    { 5, "IndiGo", new DateTime(2026, 11, 16, 9, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 11, 16, 6, 30, 0, 0, DateTimeKind.Unspecified), "DXB", "6E301", 16000m, "MAA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_Source_Destination_DepartureTime",
                table: "Flights",
                columns: new[] { "Source", "Destination", "DepartureTime" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Flights_Source_Destination_DepartureTime",
                table: "Flights");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
