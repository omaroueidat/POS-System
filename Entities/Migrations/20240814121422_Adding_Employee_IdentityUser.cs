using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Adding_Employee_IdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Employee",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a1"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "2fb4f10c-4a4b-4da4-b56e-73503d3d0f49", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a2"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "e7d78294-b48e-4919-bd34-5259939bad7f", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a3"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "7bf72a0d-0bd2-48d6-87eb-4a7d50fc5eda", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a4"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "b38aa088-72fc-4a54-bfc8-28b23b433d8b", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a5"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "44a5f1f3-aa1e-4f9a-8180-a2bf1aec4565", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "d6f6316a-a5a2-43c0-8bdb-22db20e8f1d0", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ab"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "b0a5327f-a303-432b-8ba7-4b2febad4c33", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ac"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "97dba193-06e7-4ec1-995b-3e7303fc5edd", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ad"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "bb1af46e-f1c2-4f39-a926-bd96d58c82a7", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ae"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "09f76024-aa3b-42e1-91a9-a57ea36302cf", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86af"),
                columns: new[] { "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 0, "aeab970c-23da-491e-aeb9-d7b95f54b50d", null, false, new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, false, null, false, null });

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "37e88e95-56bb-44c2-9074-ec2e79da5482");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "2d6e747c-621a-4466-9d2d-487acac65389");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Employee");

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
