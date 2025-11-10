using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchingPlacement_DispatchingDetail_DispatchingDetailID",
                table: "DispatchingPlacement");

            migrationBuilder.DropTable(
                name: "DispatchingDetailLog");

            migrationBuilder.DropTable(
                name: "DispatchingDetail");

            migrationBuilder.RenameColumn(
                name: "DispatchingDetailID",
                table: "DispatchingPlacement",
                newName: "DispatchingID");

            migrationBuilder.RenameIndex(
                name: "IX_DispatchingPlacement_DispatchingDetailID",
                table: "DispatchingPlacement",
                newName: "IX_DispatchingPlacement_DispatchingID");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchingPlacement_Dispatching_DispatchingID",
                table: "DispatchingPlacement",
                column: "DispatchingID",
                principalTable: "Dispatching",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchingPlacement_Dispatching_DispatchingID",
                table: "DispatchingPlacement");

            migrationBuilder.RenameColumn(
                name: "DispatchingID",
                table: "DispatchingPlacement",
                newName: "DispatchingDetailID");

            migrationBuilder.RenameIndex(
                name: "IX_DispatchingPlacement_DispatchingID",
                table: "DispatchingPlacement",
                newName: "IX_DispatchingPlacement_DispatchingDetailID");

            migrationBuilder.CreateTable(
                name: "DispatchingDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchingID = table.Column<int>(type: "int", nullable: true),
                    ReceivingPlacementID = table.Column<int>(type: "int", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchingDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispatchingDetail_Dispatching_DispatchingID",
                        column: x => x.DispatchingID,
                        principalTable: "Dispatching",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DispatchingDetail_ReceivingPlacement_ReceivingPlacementID",
                        column: x => x.ReceivingPlacementID,
                        principalTable: "ReceivingPlacement",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DispatchingDetailLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchingDetailID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchingDetailLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispatchingDetailLog_DispatchingDetail_DispatchingDetailID",
                        column: x => x.DispatchingDetailID,
                        principalTable: "DispatchingDetail",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DispatchingDetailLog_User_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingDetail_DispatchingID",
                table: "DispatchingDetail",
                column: "DispatchingID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingDetail_ReceivingPlacementID",
                table: "DispatchingDetail",
                column: "ReceivingPlacementID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingDetailLog_DispatchingDetailID",
                table: "DispatchingDetailLog",
                column: "DispatchingDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingDetailLog_UpdaterID",
                table: "DispatchingDetailLog",
                column: "UpdaterID");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchingPlacement_DispatchingDetail_DispatchingDetailID",
                table: "DispatchingPlacement",
                column: "DispatchingDetailID",
                principalTable: "DispatchingDetail",
                principalColumn: "ID");
        }
    }
}
