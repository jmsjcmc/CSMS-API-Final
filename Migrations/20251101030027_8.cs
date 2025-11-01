using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CompanyLog_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RepresentativeLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepresentativeID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepresentativeLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RepresentativeLog_Representative_RepresentativeID",
                        column: x => x.RepresentativeID,
                        principalTable: "Representative",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLog_CompanyID",
                table: "CompanyLog",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeLog_RepresentativeID",
                table: "RepresentativeLog",
                column: "RepresentativeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyLog");

            migrationBuilder.DropTable(
                name: "RepresentativeLog");
        }
    }
}
