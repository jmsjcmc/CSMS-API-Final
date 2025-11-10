using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlacementStatus",
                table: "DispatchingPlacement",
                newName: "CreatorID");

            migrationBuilder.AddColumn<int>(
                name: "PalletPositionStatus",
                table: "PalletPosition",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PalletOccupationStatus",
                table: "Pallet",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "DispatchingPlacement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "DispatchingPlacement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApprovalStatus",
                table: "Dispatching",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacement_CreatorID",
                table: "DispatchingPlacement",
                column: "CreatorID");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchingPlacement_User_CreatorID",
                table: "DispatchingPlacement",
                column: "CreatorID",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchingPlacement_User_CreatorID",
                table: "DispatchingPlacement");

            migrationBuilder.DropIndex(
                name: "IX_DispatchingPlacement_CreatorID",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "PalletPositionStatus",
                table: "PalletPosition");

            migrationBuilder.DropColumn(
                name: "PalletOccupationStatus",
                table: "Pallet");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "ApprovalStatus",
                table: "Dispatching");

            migrationBuilder.RenameColumn(
                name: "CreatorID",
                table: "DispatchingPlacement",
                newName: "PlacementStatus");
        }
    }
}
