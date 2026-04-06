using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ModuleA.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Schemaupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                schema: "ModuleA",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "module_a");

            migrationBuilder.RenameTable(
                name: "Users",
                schema: "ModuleA",
                newName: "users",
                newSchema: "module_a");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                schema: "module_a",
                table: "users",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                schema: "module_a",
                table: "users");

            migrationBuilder.EnsureSchema(
                name: "ModuleA");

            migrationBuilder.RenameTable(
                name: "users",
                schema: "module_a",
                newName: "Users",
                newSchema: "ModuleA");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                schema: "ModuleA",
                table: "Users",
                column: "Id");
        }
    }
}
