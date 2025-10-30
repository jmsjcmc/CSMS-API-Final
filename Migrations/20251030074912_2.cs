using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$V/JTbg48n4h3Zs4V3n5PMezUMbqJYGEhl7vN6gOQ39gxWTEEx0Q9C");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "ID",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$qhNt5i8OYkHMqMUsCrG6MuDn3MW8AMp.RHL3ui2PXHApY1dosbYw2");
        }
    }
}
