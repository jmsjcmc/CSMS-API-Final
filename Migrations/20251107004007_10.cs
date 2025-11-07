using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceivingPlacement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingProductID = table.Column<int>(type: "int", nullable: true),
                    ReceivingDetailID = table.Column<int>(type: "int", nullable: true),
                    PalletID = table.Column<int>(type: "int", nullable: true),
                    PalletPositionID = table.Column<int>(type: "int", nullable: true),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    TaggingNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CrateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingPlacement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingPlacement_PalletPosition_PalletPositionID",
                        column: x => x.PalletPositionID,
                        principalTable: "PalletPosition",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReceivingPlacement_Pallet_PalletID",
                        column: x => x.PalletID,
                        principalTable: "Pallet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReceivingPlacement_ReceivingDetail_ReceivingDetailID",
                        column: x => x.ReceivingDetailID,
                        principalTable: "ReceivingDetail",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReceivingPlacement_ReceivingProduct_ReceivingProductID",
                        column: x => x.ReceivingProductID,
                        principalTable: "ReceivingProduct",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReceivingPlacementLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingPlacementID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingPlacementLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingPlacementLog_ReceivingPlacement_ReceivingPlacementID",
                        column: x => x.ReceivingPlacementID,
                        principalTable: "ReceivingPlacement",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPlacement_PalletID",
                table: "ReceivingPlacement",
                column: "PalletID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPlacement_PalletPositionID",
                table: "ReceivingPlacement",
                column: "PalletPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPlacement_ReceivingDetailID",
                table: "ReceivingPlacement",
                column: "ReceivingDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPlacement_ReceivingProductID",
                table: "ReceivingPlacement",
                column: "ReceivingProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPlacementLog_ReceivingPlacementID",
                table: "ReceivingPlacementLog",
                column: "ReceivingPlacementID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivingPlacementLog");

            migrationBuilder.DropTable(
                name: "ReceivingPlacement");
        }
    }
}
