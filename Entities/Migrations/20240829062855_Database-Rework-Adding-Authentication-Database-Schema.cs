using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class DatabaseReworkAddingAuthenticationDatabaseSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    CustomerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuperMarket",
                columns: table => new
                {
                    SuperMarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupermarketName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperMarket", x => x.SuperMarketId);
                    table.ForeignKey(
                        name: "FK_SuperMarket_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductCode = table.Column<long>(type: "bigint", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupermarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmployeeImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_SuperMarket_SupermarketId",
                        column: x => x.SupermarketId,
                        principalTable: "SuperMarket",
                        principalColumn: "SuperMarketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuperMarketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.StockId);
                    table.ForeignKey(
                        name: "FK_Stock_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_SuperMarket_SuperMarketId",
                        column: x => x.SuperMarketId,
                        principalTable: "SuperMarket",
                        principalColumn: "SuperMarketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLog",
                columns: table => new
                {
                    EmployeeLogId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LogInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogOutDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLog", x => x.EmployeeLogId);
                    table.ForeignKey(
                        name: "FK_EmployeeLog_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.InvoiceId);
                    table.ForeignKey(
                        name: "FK_Invoice_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerInvoice",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInvoice", x => new { x.CustomerId, x.InvoiceId });
                    table.ForeignKey(
                        name: "FK_CustomerInvoice_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerInvoice_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                columns: table => new
                {
                    InvoiceDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.InvoiceDetailsId);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceDetails_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesHistory",
                columns: table => new
                {
                    SalesHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Profit = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesHistory", x => x.SalesHistoryId);
                    table.ForeignKey(
                        name: "FK_SalesHistory_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "InvoiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3c356507-2ddb-42a8-b524-ccd91bdb6907"), null, "Admin", "ADMIN" },
                    { new Guid("3cea128b-61a8-4f3c-9e9f-4746373900c5"), null, "Employee", "EMPLOYEE" },
                    { new Guid("829c81b7-4d09-40c1-8c85-bdd122f80e4a"), null, "SuperMarket", "SUPERMARKET" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Role", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeaa"), 0, "a64e30d5-78ed-46b2-83ab-e2da038dead8", "admin@gmail.com", false, false, null, "ADMIN@GMAIL.COM", "ADMIN", null, null, false, "Admin", null, false, "admin" },
                    { new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeab"), 0, "c2248349-55f9-4d40-83eb-fa29a0436f33", "tawfeer@gmail.com", false, false, null, "TAWFEER@GMAIL.COM", "TAWFEER", null, null, false, "SuperMarket", null, false, "tawfeer" },
                    { new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeac"), 0, "6b32e614-0771-4495-9809-f4177da28b4b", "employee@gmail.com", false, false, null, "EMPLOYEE@GMAIL.COM", "EMPLOYEE", null, null, false, "Employee", null, false, "employee" }
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryId", "CategoryImage", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97a"), null, "Drinks" },
                    { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97b"), null, "Food" },
                    { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97c"), null, "Accessories" },
                    { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97d"), null, "Bakery" },
                    { new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), null, "Meat" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CustomerAddress", "CustomerName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0f4d2c4b-3c2a-4d58-962f-8b1a1e5d6d89"), "456 Walnut St, Springfield", "Rachel Hill", 23457 },
                    { new Guid("2b98e616-8e6a-4c4a-8908-7e8f6c6b9f7e"), "456 Willow St, Springfield", "Frank Harris", 89012 },
                    { new Guid("2d7418db-c4e4-44c4-947f-e8dc56f0c517"), "321 Maple St, Springfield", "Bob Brown", 45678 },
                    { new Guid("4f4d08a4-8827-4d65-89a6-0a50f4769fa4"), "654 Cedar St, Springfield", "Charlie Davis", 56789 },
                    { new Guid("5e14a6b8-d89c-4a9b-a57d-d53b6f073b1f"), "987 Oak St, Springfield", "Paul King", 90123 },
                    { new Guid("5e1d1c9c-8f2a-4b0b-bcf7-1c44e5a62e1d"), "456 Oak St, Springfield", "Jane Smith", 23456 },
                    { new Guid("6e8e03c6-8d21-44a3-9f5d-17443477d05f"), "321 Oak St, Springfield", "Henry Lewis", 12345 },
                    { new Guid("7f62de52-2c1e-4a79-9e46-3d2f5e1d8e43"), "789 Maple St, Springfield", "Grace Clark", 90123 },
                    { new Guid("a638dfb5-8a52-4fcf-b9e1-4a732df8a38c"), "654 Pine St, Springfield", "Ivy Walker", 23456 },
                    { new Guid("a8e3c9b1-6c1d-4d78-9d2a-4f5b6c7d8e9f"), "987 Walnut St, Springfield", "Victor Wood", 67891 },
                    { new Guid("adad9f9c-94a7-4a07-9a51-8c5c5c8d80cf"), "789 Walnut St, Springfield", "Mia Scott", 67890 },
                    { new Guid("b1adfce6-5d7c-4c2b-8963-07e2e3c0c4a1"), "123 Birch St, Springfield", "Quincy Green", 12346 },
                    { new Guid("b2e8a3c2-17e5-49b1-b0d9-3a6e7e8f9d1e"), "654 Birch St, Springfield", "Ursula Morgan", 56780 },
                    { new Guid("c4c1d85b-f09e-48a0-8f1e-2b4c1d2f6a2d"), "321 Cedar St, Springfield", "Tina Lee", 45679 },
                    { new Guid("c8f76e8d-1b9e-4d3d-8d58-20b2a0f11a3b"), "987 Birch St, Springfield", "David Wilson", 67890 },
                    { new Guid("d1e6a2f5-0d5a-4d35-835b-623eaf6b3b43"), "123 Elm St, Springfield", "John Doe", 12345 },
                    { new Guid("d6f2a9b1-4381-4ef0-8f9b-1a2e3c4d5b67"), "789 Willow St, Springfield", "Steve Harris", 34568 },
                    { new Guid("df6840f1-517b-4c51-9a4d-b8b9e5b4c59c"), "456 Birch St, Springfield", "Liam Young", 56789 },
                    { new Guid("e0d11f8f-fb26-4b58-9b1b-fb18c8b01a2e"), "789 Pine St, Springfield", "Alice Johnson", 34567 },
                    { new Guid("e4a7d7f5-3196-4cc8-9142-9d5ab0d8a746"), "123 Cedar St, Springfield", "Kathy Allen", 45678 },
                    { new Guid("e9f2b3e7-ff84-4e7b-989d-d582f4a0e1d6"), "654 Maple St, Springfield", "Olivia Nelson", 89012 },
                    { new Guid("f0a7c573-55e8-4db1-b31f-93e7b72d4f1d"), "321 Willow St, Springfield", "Noah Adams", 78901 },
                    { new Guid("f4e5b029-3b58-4a67-b1b6-2d23ac7f69d2"), "123 Walnut St, Springfield", "Emma Taylor", 78901 },
                    { new Guid("fabc3a9d-98b4-4c62-9440-5b1e1caa74a2"), "987 Elm St, Springfield", "Jack Hall", 34567 }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminId", "AppUserId" },
                values: new object[] { new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeac"), new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeaa") });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "ProductId", "CategoryId", "Cost", "Description", "Discount", "ExpDate", "ManDate", "Price", "ProductCode", "ProductImage" },
                values: new object[,]
                {
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd41"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5f, 0L, null },
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4a"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.5f, 0L, null },
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4b"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97a"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0.99f, 0L, null },
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4c"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.2f, 0L, null },
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4d"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2f, 0L, null },
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4e"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97e"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1f, 0L, null },
                    { new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4f"), new Guid("63e2c242-e7c2-4ac1-8545-8c635c2cb97d"), 0f, null, 0m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5f, 0L, null }
                });

            migrationBuilder.InsertData(
                table: "SuperMarket",
                columns: new[] { "SuperMarketId", "Address", "AppUserId", "PhoneNumber", "SupermarketName" },
                values: new object[] { new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), null, new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeab"), 0, "Tawfeer" });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "Address", "AppUserId", "EmployeeImage", "EmployeeName", "PhoneNumber", "SupermarketId" },
                values: new object[] { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), "1 Main St", new Guid("57c34bc4-a4d5-4124-8f95-db13978fbeac"), null, "Emily Roberts", 1234, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") });

            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "StockId", "ProductId", "Quantity", "SuperMarketId" },
                values: new object[,]
                {
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd81"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd41"), 80L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") },
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8a"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4a"), 100L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") },
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8b"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4b"), 150L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") },
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8c"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4c"), 200L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") },
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8d"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4d"), 180L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") },
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8e"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4e"), 120L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") },
                    { new Guid("5983cb43-1364-4227-bbf0-0c6ade03bd8f"), new Guid("d37d22d5-ba61-4d70-ba0c-b7adff04cd4f"), 90L, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791") }
                });

            migrationBuilder.InsertData(
                table: "EmployeeLog",
                columns: new[] { "EmployeeLogId", "EmployeeId", "LogInDate", "LogOutDate" },
                values: new object[] { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ba"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Invoice",
                columns: new[] { "InvoiceId", "EmployeeId", "Total" },
                values: new object[,]
                {
                    { new Guid("b8b1d94c-7b45-4f7e-8b79-3a24894d4a77"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 150.75f },
                    { new Guid("c9a9e9d1-d23d-4f63-a1b3-0a0f7e62ec99"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 220.5f },
                    { new Guid("d1c3b8a2-41c8-4b27-9f7e-9a4f8e2a6d8b"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 350f },
                    { new Guid("e2d5a4c1-0c5f-4d1a-9c9a-f7a6b0e1e76a"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 190.25f },
                    { new Guid("f3e6d9b2-1d6a-4e4a-8f0a-4c6b9f7e8e8b"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 175f },
                    { new Guid("f4b8d1c5-7a6b-4b2a-8d2e-8f9c4d5e0d8f"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 220f },
                    { new Guid("f5c9e2d1-3b5d-4e4b-8e9d-7f6b1c0a8d7e"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 140.75f },
                    { new Guid("f6d7b8e2-4c6e-4a0f-8f1c-9e3d4b5e6c7f"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 310f },
                    { new Guid("f7e8c9d3-5b7f-4c1a-9e8b-0a1d2e3f4b6c"), new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 275.5f }
                });

            migrationBuilder.InsertData(
                table: "CustomerInvoice",
                columns: new[] { "CustomerId", "InvoiceId" },
                values: new object[,]
                {
                    { new Guid("2b98e616-8e6a-4c4a-8908-7e8f6c6b9f7e"), new Guid("d1c3b8a2-41c8-4b27-9f7e-9a4f8e2a6d8b") },
                    { new Guid("2d7418db-c4e4-44c4-947f-e8dc56f0c517"), new Guid("e2d5a4c1-0c5f-4d1a-9c9a-f7a6b0e1e76a") },
                    { new Guid("4f4d08a4-8827-4d65-89a6-0a50f4769fa4"), new Guid("f3e6d9b2-1d6a-4e4a-8f0a-4c6b9f7e8e8b") },
                    { new Guid("5e1d1c9c-8f2a-4b0b-bcf7-1c44e5a62e1d"), new Guid("c9a9e9d1-d23d-4f63-a1b3-0a0f7e62ec99") },
                    { new Guid("6e8e03c6-8d21-44a3-9f5d-17443477d05f"), new Guid("f3e6d9b2-1d6a-4e4a-8f0a-4c6b9f7e8e8b") },
                    { new Guid("7f62de52-2c1e-4a79-9e46-3d2f5e1d8e43"), new Guid("e2d5a4c1-0c5f-4d1a-9c9a-f7a6b0e1e76a") },
                    { new Guid("c8f76e8d-1b9e-4d3d-8d58-20b2a0f11a3b"), new Guid("b8b1d94c-7b45-4f7e-8b79-3a24894d4a77") },
                    { new Guid("d1e6a2f5-0d5a-4d35-835b-623eaf6b3b43"), new Guid("b8b1d94c-7b45-4f7e-8b79-3a24894d4a77") },
                    { new Guid("e0d11f8f-fb26-4b58-9b1b-fb18c8b01a2e"), new Guid("d1c3b8a2-41c8-4b27-9f7e-9a4f8e2a6d8b") },
                    { new Guid("f4e5b029-3b58-4a67-b1b6-2d23ac7f69d2"), new Guid("c9a9e9d1-d23d-4f63-a1b3-0a0f7e62ec99") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AppUserId",
                table: "Admin",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerInvoice_InvoiceId",
                table: "CustomerInvoice",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee",
                column: "AppUserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SupermarketId",
                table: "Employee",
                column: "SupermarketId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLog_EmployeeId",
                table: "EmployeeLog",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_EmployeeId",
                table: "Invoice",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                table: "InvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesHistory_InvoiceId",
                table: "SalesHistory",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_ProductId",
                table: "Stock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_SuperMarketId",
                table: "Stock",
                column: "SuperMarketId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperMarket_AppUserId",
                table: "SuperMarket",
                column: "AppUserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CustomerInvoice");

            migrationBuilder.DropTable(
                name: "EmployeeLog");

            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "SalesHistory");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "SuperMarket");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
