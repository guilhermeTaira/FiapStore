using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiapStore.Migrations
{
    /// <inheritdoc />
    public partial class Add_user_password_permission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "User",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "User",
                type: "VARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "User");
        }
    }
}
