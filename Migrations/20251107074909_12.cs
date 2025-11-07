using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ReceivingPlacement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreatorID",
                table: "ReceivingPlacement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingPlacement_CreatorID",
                table: "ReceivingPlacement",
                column: "CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingPlacement_User_CreatorID",
                table: "ReceivingPlacement",
                column: "CreatorID",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingPlacement_User_CreatorID",
                table: "ReceivingPlacement");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingPlacement_CreatorID",
                table: "ReceivingPlacement");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ReceivingPlacement");

            migrationBuilder.DropColumn(
                name: "CreatorID",
                table: "ReceivingPlacement");
        }
    }
}
