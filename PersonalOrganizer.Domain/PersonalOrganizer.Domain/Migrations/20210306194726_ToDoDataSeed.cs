using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalOrganizer.Domain.Migrations
{
    public partial class ToDoDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ToDos",
                columns: new[] { "Id", "DateCompleted", "DateCreated", "Description", "IsCompleted" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2021, 3, 6, 14, 47, 25, 536, DateTimeKind.Local).AddTicks(2600), "Feed the dog", false },
                    { 2L, null, new DateTime(2021, 3, 6, 14, 47, 25, 552, DateTimeKind.Local).AddTicks(50), "Feed the cat", false },
                    { 3L, null, new DateTime(2021, 3, 6, 14, 47, 25, 552, DateTimeKind.Local).AddTicks(70), "Walk the dog", false },
                    { 4L, null, new DateTime(2021, 3, 6, 14, 47, 25, 552, DateTimeKind.Local).AddTicks(70), "Change cat litter", false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
