using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class POS_Database_AlterTables : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
