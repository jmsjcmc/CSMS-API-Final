using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Position",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "Department",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "UserRole");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Position");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "Department");
        }
    }
}
