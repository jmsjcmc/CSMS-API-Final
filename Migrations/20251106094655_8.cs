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
                name: "ReceivingProduct",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    TotalQuantity = table.Column<int>(type: "int", nullable: true),
                    TotalWeight = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReceivingProduct_Receiving_ReceivingID",
                        column: x => x.ReceivingID,
                        principalTable: "Receiving",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLog_UpdaterID",
                table: "ReceivingLog",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetailLog_UpdaterID",
                table: "ReceivingDetailLog",
                column: "UpdaterID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetail_CreatorID",
                table: "ReceivingDetail",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_CreatorID",
                table: "Receiving",
                column: "CreatorID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingProduct_ProductID",
                table: "ReceivingProduct",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingProduct_ReceivingID",
                table: "ReceivingProduct",
                column: "ReceivingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Receiving_User_CreatorID",
                table: "Receiving",
                column: "CreatorID",
                principalTable: "User",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetail_User_CreatorID",
                table: "ReceivingDetail",
                column: "CreatorID",
                principalTable: "User",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingDetailLog_User_UpdaterID",
                table: "ReceivingDetailLog",
                column: "UpdaterID",
                principalTable: "User",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingLog_User_UpdaterID",
                table: "ReceivingLog",
                column: "UpdaterID",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receiving_User_CreatorID",
                table: "Receiving");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetail_User_CreatorID",
                table: "ReceivingDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingDetailLog_User_UpdaterID",
                table: "ReceivingDetailLog");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingLog_User_UpdaterID",
                table: "ReceivingLog");

            migrationBuilder.DropTable(
                name: "ReceivingProduct");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingLog_UpdaterID",
                table: "ReceivingLog");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingDetailLog_UpdaterID",
                table: "ReceivingDetailLog");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingDetail_CreatorID",
                table: "ReceivingDetail");

            migrationBuilder.DropIndex(
                name: "IX_Receiving_CreatorID",
                table: "Receiving");
        }
    }
}
