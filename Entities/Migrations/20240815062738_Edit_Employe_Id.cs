using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class Edit_Employe_Id : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLog_Employee_EmployeeId",
                table: "EmployeeLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePasscode_Employee_EmployeeId",
                table: "EmployeePasscode");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Employee_EmployeeId",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a1"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a2"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a3"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a4"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a5"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ab"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ac"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ad"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ae"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "EmployeeId",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86af"));

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeImage", "EmployeeName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SupermarketId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a1"), 0, "7 Maple St", "e071d34a-a75b-470f-9154-678b00535a72", null, false, null, "Mia Wilson", false, null, null, null, null, 7890, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a2"), 0, "8 Birch St", "494e15ee-6129-4dc5-987f-d6add6c098cc", null, false, null, "James Miller", false, null, null, null, null, 8901, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a3"), 0, "9 Cedar St", "b930bdc4-7d9d-42a5-b3d7-a303c909ba51", null, false, null, "Ava Taylor", false, null, null, null, null, 9012, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a4"), 0, "10 Spruce St", "4b7942f2-9819-4351-b950-9a03004444ef", null, false, null, "Ethan Anderson", false, null, null, null, null, 1234, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a5"), 0, "11 Willow St", "3cad6205-cc26-4a51-9fc2-423235f7a7b2", null, false, null, "Olivia Harris", false, null, null, null, null, 1234, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 0, "1 Main St", "13f39c2f-3d7f-44ee-8a0d-55dead760ace", null, false, null, "Emily Roberts", false, null, null, null, null, 1234, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ab"), 0, "2 Main St", "7fdada03-4b3f-456d-a62b-60c3085ccbf9", null, false, null, "Michael Johnson", false, null, null, null, null, 2345, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ac"), 0, "3 Elm St", "9d4f09e2-0f5b-4d9e-aa0e-c0045683d4d8", null, false, null, "Sophia Williams", false, null, null, null, null, 3456, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ad"), 0, "4 Elm St", "504d9ec8-523f-443a-9bbd-c6ce3aaaaca5", null, false, null, "Oliver Brown", false, null, null, null, null, 4567, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ae"), 0, "5 Oak St", "00cfb597-94f4-4f83-b2bb-e41fce451802", null, false, null, "Isabella Davis", false, null, null, null, null, 5678, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86af"), 0, "6 Pine St", "1d86c858-ad35-40b0-86e8-2d2695edfb62", null, false, null, "Liam Martinez", false, null, null, null, null, 6789, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null }
                });

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"),
                column: "ConcurrencyStamp",
                value: "0719039d-2ae2-4bb3-b138-7013d5e3d40f");

            migrationBuilder.UpdateData(
                table: "SuperMarket",
                keyColumn: "Id",
                keyValue: new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"),
                column: "ConcurrencyStamp",
                value: "b1cbcc3f-5456-4412-8092-966a82761026");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLog_Employee_EmployeeId",
                table: "EmployeeLog",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePasscode_Employee_EmployeeId",
                table: "EmployeePasscode",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Employee_EmployeeId",
                table: "Invoice",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeLog_Employee_EmployeeId",
                table: "EmployeeLog");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeePasscode_Employee_EmployeeId",
                table: "EmployeePasscode");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoice_Employee_EmployeeId",
                table: "Invoice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a1"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a2"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a3"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a4"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a5"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ab"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ac"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ad"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ae"));

            migrationBuilder.DeleteData(
                table: "Employee",
                keyColumn: "Id",
                keyValue: new Guid("536d010d-465c-4c4b-84e9-18d5df4d86af"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Employee",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeId");

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "EmployeeId", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeImage", "EmployeeName", "Id", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SupermarketId", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a1"), 0, "7 Maple St", "2fb4f10c-4a4b-4da4-b56e-73503d3d0f49", null, false, null, "Mia Wilson", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 7890, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a2"), 0, "8 Birch St", "e7d78294-b48e-4919-bd34-5259939bad7f", null, false, null, "James Miller", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 8901, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a3"), 0, "9 Cedar St", "7bf72a0d-0bd2-48d6-87eb-4a7d50fc5eda", null, false, null, "Ava Taylor", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 9012, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a4"), 0, "10 Spruce St", "b38aa088-72fc-4a54-bfc8-28b23b433d8b", null, false, null, "Ethan Anderson", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 1234, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86a5"), 0, "11 Willow St", "44a5f1f3-aa1e-4f9a-8180-a2bf1aec4565", null, false, null, "Olivia Harris", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 1234, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203792"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86aa"), 0, "1 Main St", "d6f6316a-a5a2-43c0-8bdb-22db20e8f1d0", null, false, null, "Emily Roberts", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 1234, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ab"), 0, "2 Main St", "b0a5327f-a303-432b-8ba7-4b2febad4c33", null, false, null, "Michael Johnson", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 2345, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ac"), 0, "3 Elm St", "97dba193-06e7-4ec1-995b-3e7303fc5edd", null, false, null, "Sophia Williams", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 3456, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ad"), 0, "4 Elm St", "bb1af46e-f1c2-4f39-a926-bd96d58c82a7", null, false, null, "Oliver Brown", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 4567, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86ae"), 0, "5 Oak St", "09f76024-aa3b-42e1-91a9-a57ea36302cf", null, false, null, "Isabella Davis", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 5678, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null },
                    { new Guid("536d010d-465c-4c4b-84e9-18d5df4d86af"), 0, "6 Pine St", "aeab970c-23da-491e-aeb9-d7b95f54b50d", null, false, null, "Liam Martinez", new Guid("00000000-0000-0000-0000-000000000000"), false, null, null, null, null, 6789, false, null, new Guid("5f2cfd7a-f135-4dad-9ebd-97014f203791"), false, null }
                });

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

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeLog_Employee_EmployeeId",
                table: "EmployeeLog",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeePasscode_Employee_EmployeeId",
                table: "EmployeePasscode",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoice_Employee_EmployeeId",
                table: "Invoice",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
