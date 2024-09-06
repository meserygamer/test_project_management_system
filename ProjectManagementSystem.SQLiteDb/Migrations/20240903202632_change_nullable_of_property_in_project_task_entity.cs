using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementSystem.SQLiteDb.Migrations
{
    /// <inheritdoc />
    public partial class change_nullable_of_property_in_project_task_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Users_ResponsibleUserId",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleUserId",
                table: "ProjectTasks",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.UpdateData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2024, 9, 3, 23, 26, 32, 335, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Users_ResponsibleUserId",
                table: "ProjectTasks",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectTasks_Users_ResponsibleUserId",
                table: "ProjectTasks");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsibleUserId",
                table: "ProjectTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ProjectTasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "StartTime",
                value: new DateTime(2024, 9, 3, 15, 55, 24, 573, DateTimeKind.Local).AddTicks(7206));

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectTasks_Users_ResponsibleUserId",
                table: "ProjectTasks",
                column: "ResponsibleUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
