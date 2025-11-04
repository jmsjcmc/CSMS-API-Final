using System;
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
            migrationBuilder.CreateTable(
                name: "ColdStorage",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdStorage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Pallet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pallet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ColdStorageLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColdStorageID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColdStorageLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ColdStorageLog_ColdStorage_ColdStorageID",
                        column: x => x.ColdStorageID,
                        principalTable: "ColdStorage",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PalletPosition",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColdStorageID = table.Column<int>(type: "int", nullable: true),
                    Wing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Column = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Side = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletPosition", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PalletPosition_ColdStorage_ColdStorageID",
                        column: x => x.ColdStorageID,
                        principalTable: "ColdStorage",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PalletLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalletID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PalletLog_Pallet_PalletID",
                        column: x => x.PalletID,
                        principalTable: "Pallet",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "PalletPositionLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PalletPositionID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PalletPositionLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PalletPositionLog_PalletPosition_PalletPositionID",
                        column: x => x.PalletPositionID,
                        principalTable: "PalletPosition",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ColdStorageLog_ColdStorageID",
                table: "ColdStorageLog",
                column: "ColdStorageID");

            migrationBuilder.CreateIndex(
                name: "IX_PalletLog_PalletID",
                table: "PalletLog",
                column: "PalletID");

            migrationBuilder.CreateIndex(
                name: "IX_PalletPosition_ColdStorageID",
                table: "PalletPosition",
                column: "ColdStorageID");

            migrationBuilder.CreateIndex(
                name: "IX_PalletPositionLog_PalletPositionID",
                table: "PalletPositionLog",
                column: "PalletPositionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColdStorageLog");

            migrationBuilder.DropTable(
                name: "PalletLog");

            migrationBuilder.DropTable(
                name: "PalletPositionLog");

            migrationBuilder.DropTable(
                name: "Pallet");

            migrationBuilder.DropTable(
                name: "PalletPosition");

            migrationBuilder.DropTable(
                name: "ColdStorage");
        }
    }
}
