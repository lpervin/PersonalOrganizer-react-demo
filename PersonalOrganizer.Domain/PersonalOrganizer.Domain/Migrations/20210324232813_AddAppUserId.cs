using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalOrganizer.Domain.Migrations
{
    public partial class AddAppUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 28, 13, 357, DateTimeKind.Local).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 28, 13, 369, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 28, 13, 369, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 28, 13, 369, DateTimeKind.Local).AddTicks(6060));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 20, 29, 961, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 20, 29, 974, DateTimeKind.Local).AddTicks(220));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 20, 29, 974, DateTimeKind.Local).AddTicks(250));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 20, 29, 974, DateTimeKind.Local).AddTicks(260));
        }
    }
}
