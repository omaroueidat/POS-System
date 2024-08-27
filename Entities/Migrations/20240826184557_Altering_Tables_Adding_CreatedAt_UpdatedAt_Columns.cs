using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Altering_Tables_Adding_CreatedAt_UpdatedAt_Columns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "dd8472e6-f64b-4076-a191-b88c2e732295");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "0f203588-4615-4bec-a629-e618f533c57d");

            // Add CreatedAt and UpdatedAt to SuperMarket
            migrationBuilder.Sql(@"
                ALTER TABLE SuperMarket
                ADD CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE();
            ");

            // Add CreatedAt and UpdatedAt to Employee
            migrationBuilder.Sql(@"
                ALTER TABLE Employee
                ADD CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE();
            ");

            // Add only UpdatedAt to Stock
            migrationBuilder.Sql(@"
                ALTER TABLE Stock
                ADD UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE();
            ");

            // Add only CreatedAt to Invoice
            migrationBuilder.Sql(@"
                ALTER TABLE Invoice
                ADD CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE();
            ");

            // Add Created At and Updated At to Category
            migrationBuilder.Sql(@"
                ALTER TABLE Category
                ADD CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE();
            ");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "4df54b31-6523-4a30-8fbe-03a9ed3455d9");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "7fb8e510-4c27-4268-9823-285c74aac037");
        }
    }
}
