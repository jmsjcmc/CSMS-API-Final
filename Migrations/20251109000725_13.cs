using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dispatching",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DispatchTimeStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchTimeEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NMISCertificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DispatchPlateNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SealNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OverAllWeight = table.Column<double>(type: "float", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    ApprovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeclinedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dispatching", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dispatching_User_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Dispatching_User_CreatorID",
                        column: x => x.CreatorID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DispatchingDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingPlacementID = table.Column<int>(type: "int", nullable: true),
                    DispatchingID = table.Column<int>(type: "int", nullable: true),
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
                name: "DispatchingLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchingID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    Updater = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchingLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispatchingLog_Dispatching_DispatchingID",
                        column: x => x.DispatchingID,
                        principalTable: "Dispatching",
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

            migrationBuilder.CreateTable(
                name: "DispatchingPlacement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingPlacementID = table.Column<int>(type: "int", nullable: true),
                    DispatchingDetailID = table.Column<int>(type: "int", nullable: true),
                    PalletID = table.Column<int>(type: "int", nullable: true),
                    PalletPositionID = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchingPlacement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispatchingPlacement_DispatchingDetail_DispatchingDetailID",
                        column: x => x.DispatchingDetailID,
                        principalTable: "DispatchingDetail",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DispatchingPlacement_PalletPosition_PalletPositionID",
                        column: x => x.PalletPositionID,
                        principalTable: "PalletPosition",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DispatchingPlacement_Pallet_PalletID",
                        column: x => x.PalletID,
                        principalTable: "Pallet",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DispatchingPlacement_ReceivingPlacement_ReceivingPlacementID",
                        column: x => x.ReceivingPlacementID,
                        principalTable: "ReceivingPlacement",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DispatchingPlacementLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DispatchingPlacementID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DispatchingPlacementLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DispatchingPlacementLog_DispatchingPlacement_DispatchingPlacementID",
                        column: x => x.DispatchingPlacementID,
                        principalTable: "DispatchingPlacement",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_DispatchingPlacementLog_User_UpdaterID",
                        column: x => x.UpdaterID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dispatching_ApproverID",
                table: "Dispatching",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_Dispatching_CreatorID",
                table: "Dispatching",
                column: "CreatorID");

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

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingLog_DispatchingID",
                table: "DispatchingLog",
                column: "DispatchingID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacement_DispatchingDetailID",
                table: "DispatchingPlacement",
                column: "DispatchingDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacement_PalletID",
                table: "DispatchingPlacement",
                column: "PalletID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacement_PalletPositionID",
                table: "DispatchingPlacement",
                column: "PalletPositionID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacement_ReceivingPlacementID",
                table: "DispatchingPlacement",
                column: "ReceivingPlacementID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacementLog_DispatchingPlacementID",
                table: "DispatchingPlacementLog",
                column: "DispatchingPlacementID");

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacementLog_UpdaterID",
                table: "DispatchingPlacementLog",
                column: "UpdaterID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DispatchingDetailLog");

            migrationBuilder.DropTable(
                name: "DispatchingLog");

            migrationBuilder.DropTable(
                name: "DispatchingPlacementLog");

            migrationBuilder.DropTable(
                name: "DispatchingPlacement");

            migrationBuilder.DropTable(
                name: "DispatchingDetail");

            migrationBuilder.DropTable(
                name: "Dispatching");
        }
    }
}
