using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedID",
                table: "RoleLog",
                newName: "UpdaterID");

            migrationBuilder.AddColumn<int>(
                name: "AssignerID",
                table: "UserRole",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRoleLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoleLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRoleLog_UserRole_UserRoleID",
                        column: x => x.UserRoleID,
                        principalTable: "UserRole",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoleLog_UserRoleID",
                table: "UserRoleLog",
                column: "UserRoleID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoleLog");

            migrationBuilder.DropColumn(
                name: "AssignerID",
                table: "UserRole");

            migrationBuilder.RenameColumn(
                name: "UpdaterID",
                table: "RoleLog",
                newName: "UpdatedID");
        }
    }
}
