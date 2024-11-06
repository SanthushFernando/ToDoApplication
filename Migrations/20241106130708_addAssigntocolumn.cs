using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApplication.Migrations
{
    /// <inheritdoc />
    public partial class addAssigntocolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Assignto",
                table: "ToDoItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assignto",
                table: "ToDoItems");
        }
    }
}
