using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EffortTracker.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Associates");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Associates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
