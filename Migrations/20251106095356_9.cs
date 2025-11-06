using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "ReceivingProduct",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReceivingProductLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingProductID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingProductLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingProductLog_ReceivingProduct_ReceivingProductID",
                        column: x => x.ReceivingProductID,
                        principalTable: "ReceivingProduct",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReceivingProductLog_User_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingProductLog_ReceivingProductID",
                table: "ReceivingProductLog",
                column: "ReceivingProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingProductLog_UpdaterID",
                table: "ReceivingProductLog",
                column: "UpdaterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivingProductLog");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "ReceivingProduct");
        }
    }
}
