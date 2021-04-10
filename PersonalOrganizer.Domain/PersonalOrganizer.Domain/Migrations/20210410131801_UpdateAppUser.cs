using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalOrganizer.Domain.Migrations
{
    public partial class UpdateAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "AppUsers",
                newName: "UserIdentifier");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "AppUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2021, 4, 10, 9, 18, 1, 423, DateTimeKind.Local).AddTicks(7500));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2021, 4, 10, 9, 18, 1, 443, DateTimeKind.Local).AddTicks(6160));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2021, 4, 10, 9, 18, 1, 443, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2021, 4, 10, 9, 18, 1, 443, DateTimeKind.Local).AddTicks(6200));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "UserIdentifier",
                table: "AppUsers",
                newName: "UserName");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 30, 19, 444, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 30, 19, 457, DateTimeKind.Local).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 30, 19, 457, DateTimeKind.Local).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 30, 19, 457, DateTimeKind.Local).AddTicks(5150));
        }
    }
}
