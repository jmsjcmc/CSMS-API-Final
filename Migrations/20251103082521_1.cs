using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CSMS_API.Migrations
{
    /// <inheritdoc />
    public partial class _1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessUnit",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnit", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnitLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessUnitID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnitLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BusinessUnitLog_BusinessUnit_BusinessUnitID",
                        column: x => x.BusinessUnitID,
                        principalTable: "BusinessUnit",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "CategoryLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CategoryLog_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                });

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
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPackaging = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeliveryUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Product_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Representative",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TelephoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyID = table.Column<int>(type: "int", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Representative", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Representative_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentLog_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Position_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "RoleLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    UpdatedID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RoleLog_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ProductLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProductLog_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
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

            migrationBuilder.CreateTable(
                name: "PositionLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PositionLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PositionLog_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessUnitID = table.Column<int>(type: "int", nullable: true),
                    PositionID = table.Column<int>(type: "int", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_BusinessUnit_BusinessUnitID",
                        column: x => x.BusinessUnitID,
                        principalTable: "BusinessUnit",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_User_Position_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Position",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Receiving",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CVNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArrivalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UnloadingStart = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnloadingEnd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ApproverID = table.Column<int>(type: "int", nullable: true),
                    DateReceived = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receiving", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Receiving_User_ApproverID",
                        column: x => x.ApproverID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserLog_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    RoleID = table.Column<int>(type: "int", nullable: true),
                    AssignedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RecordStatus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReceivingDetail",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingID = table.Column<int>(type: "int", nullable: true),
                    ProductID = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    QuantityInPallet = table.Column<int>(type: "int", nullable: true),
                    DUQuantity = table.Column<int>(type: "int", nullable: true),
                    TotalWeight = table.Column<double>(type: "float", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatorID = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ReceivingDetail_Receiving_ReceivingID",
                        column: x => x.ReceivingID,
                        principalTable: "Receiving",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReceivingLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingLog_Receiving_ReceivingID",
                        column: x => x.ReceivingID,
                        principalTable: "Receiving",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ReceivingDetailLog",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceivingDetailID = table.Column<int>(type: "int", nullable: true),
                    UpdaterID = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivingDetailLog", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ReceivingDetailLog_ReceivingDetail_ReceivingDetailID",
                        column: x => x.ReceivingDetailID,
                        principalTable: "ReceivingDetail",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "BusinessUnit",
                columns: new[] { "ID", "CreatedOn", "CreatorID", "Location", "Name", "RecordStatus" },
                values: new object[] { 1, null, null, "Binugao, Toril, Davao City", "ABFI", null });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "BusinessUnitID", "CreatedOn", "CreatorID", "FirstName", "LastName", "Password", "PositionID", "RecordStatus", "Username" },
                values: new object[] { 1, 1, null, null, "James", "Tabilog", "$2a$11$V/JTbg48n4h3Zs4V3n5PMezUMbqJYGEhl7vN6gOQ39gxWTEEx0Q9C", null, 1, "211072" });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessUnitLog_BusinessUnitID",
                table: "BusinessUnitLog",
                column: "BusinessUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryLog_CategoryID",
                table: "CategoryLog",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLog_CompanyID",
                table: "CompanyLog",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentLog_DepartmentID",
                table: "DepartmentLog",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Position_DepartmentID",
                table: "Position",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_PositionLog_PositionID",
                table: "PositionLog",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CompanyID",
                table: "Product",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductLog_ProductID",
                table: "ProductLog",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Receiving_ApproverID",
                table: "Receiving",
                column: "ApproverID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetail_ProductID",
                table: "ReceivingDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetail_ReceivingID",
                table: "ReceivingDetail",
                column: "ReceivingID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingDetailLog_ReceivingDetailID",
                table: "ReceivingDetailLog",
                column: "ReceivingDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingLog_ReceivingID",
                table: "ReceivingLog",
                column: "ReceivingID");

            migrationBuilder.CreateIndex(
                name: "IX_Representative_CompanyID",
                table: "Representative",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_RepresentativeLog_RepresentativeID",
                table: "RepresentativeLog",
                column: "RepresentativeID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleLog_RoleID",
                table: "RoleLog",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_User_BusinessUnitID",
                table: "User",
                column: "BusinessUnitID");

            migrationBuilder.CreateIndex(
                name: "IX_User_PositionID",
                table: "User",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_UserLog_UserID",
                table: "UserLog",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                table: "UserRole",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserID",
                table: "UserRole",
                column: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessUnitLog");

            migrationBuilder.DropTable(
                name: "CategoryLog");

            migrationBuilder.DropTable(
                name: "CompanyLog");

            migrationBuilder.DropTable(
                name: "DepartmentLog");

            migrationBuilder.DropTable(
                name: "PositionLog");

            migrationBuilder.DropTable(
                name: "ProductLog");

            migrationBuilder.DropTable(
                name: "ReceivingDetailLog");

            migrationBuilder.DropTable(
                name: "ReceivingLog");

            migrationBuilder.DropTable(
                name: "RepresentativeLog");

            migrationBuilder.DropTable(
                name: "RoleLog");

            migrationBuilder.DropTable(
                name: "UserLog");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "ReceivingDetail");

            migrationBuilder.DropTable(
                name: "Representative");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Receiving");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BusinessUnit");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
