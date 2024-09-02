using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagementSystem.SQLiteDb.Migrations
{
    /// <inheritdoc />
    public partial class AddRegularEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "HashedPassword", "Login", "Name", "Patronymic", "Surname", "UserRoleId" },
                values: new object[] { 1, "test@mail.com", "$2a$11$BS71wMsMq7URQ8UQbbBcMOWMBrc9.0MO2Wm8QhUtmJFLqhZqtBjJC", "Employee", "Работник", "Работникович", "Работников", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
