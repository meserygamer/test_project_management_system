using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProjectManagementSystem.SQLiteDb.Migrations
{
    /// <inheritdoc />
    public partial class AddDefaultTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProjectTasks",
                columns: new[] { "Id", "Description", "ResponsibleUserId", "StartTime", "TaskStatusId", "Title" },
                values: new object[,]
                {
                    { 1, "Написать маппер из класса UserEntity (Database) в User (Core)", 1, new DateTime(2024, 9, 2, 3, 16, 52, 569, DateTimeKind.Local).AddTicks(25), 1, "Написать мапперы для пользователя" },
                    { 2, "Написать класс UserEntity отображающий пользователя в БД и конфигурацию UserConfiguration", 1, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local), 2, "Написать сущность и конфигурацию для хранения пользователей" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
