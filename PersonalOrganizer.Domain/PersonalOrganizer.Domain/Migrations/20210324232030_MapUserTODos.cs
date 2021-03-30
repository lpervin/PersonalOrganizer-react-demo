using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalOrganizer.Domain.Migrations
{
    public partial class MapUserTODos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AppUserId",
                table: "ToDos",
                type: "bigint",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AppUsers_AppUserId",
                table: "ToDos",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AppUsers_AppUserId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ToDos");

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 14, 52, 278, DateTimeKind.Local).AddTicks(9320));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 14, 52, 291, DateTimeKind.Local).AddTicks(5660));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 14, 52, 291, DateTimeKind.Local).AddTicks(5690));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4L,
                column: "DateCreated",
                value: new DateTime(2021, 3, 24, 19, 14, 52, 291, DateTimeKind.Local).AddTicks(5700));
        }
    }
}
