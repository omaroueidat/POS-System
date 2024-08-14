using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Identity_Tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SuperMarket_SupermarketId",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperMarket",
                table: "SuperMarket");

            migrationBuilder.DeleteData(
                table: "SuperMarket",
                keyColumn: "SupermarketId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"));

            migrationBuilder.DeleteData(
                table: "SuperMarket",
                keyColumn: "SupermarketId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"));

            migrationBuilder.DropColumn(
                name: "SupermarketId",
                table: "SuperMarket");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SuperMarket",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SuperMarket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "SuperMarket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "SuperMarket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "SuperMarket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "SuperMarket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "SuperMarket",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "SuperMarket",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "SuperMarket",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "SuperMarket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "SuperMarket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "SuperMarket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "SuperMarket",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "SuperMarket",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperMarket",
                table: "SuperMarket",
                column: "Id");

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
                        name: "FK_AspNetUserClaims_SuperMarket_UserId",
                        column: x => x.UserId,
                        principalTable: "SuperMarket",
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
                        name: "FK_AspNetUserLogins_SuperMarket_UserId",
                        column: x => x.UserId,
                        principalTable: "SuperMarket",
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
                        name: "FK_AspNetUserTokens_SuperMarket_UserId",
                        column: x => x.UserId,
                        principalTable: "SuperMarket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_AspNetUserRoles_SuperMarket_UserId",
                        column: x => x.UserId,
                        principalTable: "SuperMarket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SuperMarket",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SupermarketName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), 0, null, "09683740-5e08-42f7-a542-960ba8037679", null, false, false, null, null, null, null, null, 0, false, null, "SuperMart Downtown", false, null },
                    { new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), 0, null, "44ad163b-2ff0-4601-a839-e1e68180d99f", null, false, false, null, null, null, null, null, 0, false, null, "SuperMart Uptown", false, null }
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "SuperMarket",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "SuperMarket",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SuperMarket_SupermarketId",
                table: "Employee",
                column: "SupermarketId",
                principalTable: "SuperMarket",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_SuperMarket_SupermarketId",
                table: "Employee");

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
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SuperMarket",
                table: "SuperMarket");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "SuperMarket");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "SuperMarket");

            migrationBuilder.DeleteData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"));

            migrationBuilder.DeleteData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "SuperMarket");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "SuperMarket");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "SuperMarket",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupermarketId",
                table: "SuperMarket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SuperMarket",
                table: "SuperMarket",
                column: "SupermarketId");

            migrationBuilder.InsertData(
                table: "SuperMarket",
                columns: new[] { "SupermarketId", "Address", "Email", "Password", "PhoneNumber", "SupermarketName" },
                values: new object[,]
                {
                    { new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), null, null, null, 0, "SuperMart Downtown" },
                    { new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), null, null, null, 0, "SuperMart Uptown" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_SuperMarket_SupermarketId",
                table: "Employee",
                column: "SupermarketId",
                principalTable: "SuperMarket",
                principalColumn: "SupermarketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
