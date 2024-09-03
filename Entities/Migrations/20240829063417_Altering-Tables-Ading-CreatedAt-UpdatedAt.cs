using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AlteringTablesAdingCreatedAtUpdatedAt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            // Add CreatedAt and UpdatedAt to SuperMarket
            migrationBuilder.Sql(@"
                ALTER TABLE SuperMarket
                Drop Column CreatedAt ,
                    UpdatedAt ;
            ");

            // Add CreatedAt and UpdatedAt to Employee
            migrationBuilder.Sql(@"
                ALTER TABLE Employee
                Drop Column CreatedAt,
                    UpdatedAt ;
            ");

            // Add only UpdatedAt to Stock
            migrationBuilder.Sql(@"     
                ALTER TABLE Stock
                Drop Column UpdatedAt;
            ");

            // Add only CreatedAt to Invoice
            migrationBuilder.Sql(@"
                ALTER TABLE Invoice
                Drop Column CreatedAt;
            ");

            // Add Created At and Updated At to Category
            migrationBuilder.Sql(@"
                ALTER TABLE Category
                Drop Column CreatedAt,
                    UpdatedAt;
            ");
        }
    }
}
