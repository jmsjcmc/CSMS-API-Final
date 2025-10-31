using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "BusinessUnit",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "BusinessUnit",
                keyColumn: "ID",
                keyValue: 1,
                column: "RecordStatus",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "BusinessUnit");
        }
    }
}
