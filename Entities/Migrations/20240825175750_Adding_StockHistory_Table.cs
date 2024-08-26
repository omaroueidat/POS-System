using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Adding_StockHistory_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "6f54e3bd-0054-46d0-bab4-805d8172e986");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "048dd59f-fd07-4317-88e0-2f30a1778ff3");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "0a03c196-5ff1-4d06-b41f-a1e991e5a816");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "d62442a2-7332-4551-8804-6e8200dabde1");
        }
    }
}
