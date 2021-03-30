using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalOrganizer.Domain.Migrations
{
    public partial class MapNotesToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AppUserId",
                table: "Notes",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Notes_AppUserId",
                table: "Notes",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AppUsers_AppUserId",
                table: "Notes",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AppUsers_AppUserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_AppUserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Notes");

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
    }
}
