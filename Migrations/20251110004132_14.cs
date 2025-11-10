using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedOn",
                table: "DispatchingPlacement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApproverID",
                table: "DispatchingPlacement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeclinedOn",
                table: "DispatchingPlacement",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PlacementStatus",
                table: "DispatchingPlacement",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecordStatus",
                table: "DispatchingPlacement",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DispatchingPlacement_ApproverID",
                table: "DispatchingPlacement",
                column: "ApproverID");

            migrationBuilder.AddForeignKey(
                name: "FK_DispatchingPlacement_User_ApproverID",
                table: "DispatchingPlacement",
                column: "ApproverID",
                principalTable: "User",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DispatchingPlacement_User_ApproverID",
                table: "DispatchingPlacement");

            migrationBuilder.DropIndex(
                name: "IX_DispatchingPlacement_ApproverID",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "ApprovedOn",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "ApproverID",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "DeclinedOn",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "PlacementStatus",
                table: "DispatchingPlacement");

            migrationBuilder.DropColumn(
                name: "RecordStatus",
                table: "DispatchingPlacement");
        }
    }
}
