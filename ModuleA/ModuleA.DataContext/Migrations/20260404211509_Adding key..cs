using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleA.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class Addingkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "ModuleA");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Users",
                newSchema: "ModuleA");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "ModuleA",
                table: "Users",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Users",
                schema: "ModuleA",
                newName: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);
        }
    }
}
