using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementSystem.SQLiteDb.Migrations
{
    /// <inheritdoc />
    public partial class add_test_supervisor_user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2024, 9, 3, 15, 55, 24, 573, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.UpdateData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Login", "Name", "Patronymic", "Surname", "UserRoleId" },
                values: new object[] { 2, "test@mail.com", "$2a$11$BS71wMsMq7URQ8UQbbBcMOWMBrc9.0MO2Wm8QhUtmJFLqhZqtBjJC", "Supervisor", "Управляющий", "Управляющевич", "Управ", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2024, 9, 2, 3, 16, 52, 569, DateTimeKind.Local).AddTicks(25));

            migrationBuilder.UpdateData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "StartTime",
                value: new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
