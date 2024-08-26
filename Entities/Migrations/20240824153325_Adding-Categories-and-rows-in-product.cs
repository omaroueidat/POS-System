using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddingCategoriesandrowsinproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SuperMarketId",
                table: "Stock",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Product",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Product",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd41"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4a"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4b"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97a"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4c"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4d"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4e"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ProductId",
                keyValue: new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4f"),
                columns: new[] { "CategoryId", "Description", "Discount", "ProductImage" },
                values: new object[] { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97d"), null, 0m, null });

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd81"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8a"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8b"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8c"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8d"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8e"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Stock",
                keyColumn: "StockId",
                keyValue: new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8f"),
                column: "SuperMarketId",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SuperMarketId",
                table: "Stock",
                column: "SuperMarketId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stock_SuperMarket_SuperMarketId",
                table: "Stock",
                column: "SuperMarketId",
                principalTable: "SuperMarket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            // Adding CreatedAt and UpdatedAt to table Category
            migrationBuilder.Sql(@"
                ALTER TABLE Category
                ADD CreatedAt DATETIME2 NOT NULL DEFAULT GETDATE(),
                    UpdatedAt DATETIME2 NOT NULL DEFAULT GETDATE();
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Stock_SuperMarket_SuperMarketId",
                table: "Stock");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Stock_SuperMarketId",
                table: "Stock");

            migrationBuilder.DropIndex(
                name: "IX_Product_CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "SuperMarketId",
                table: "Stock");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "09683740-5e08-42f7-a542-960ba8037679");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "44ad163b-2ff0-4601-a839-e1e68180d99f");
        }
    }
}
