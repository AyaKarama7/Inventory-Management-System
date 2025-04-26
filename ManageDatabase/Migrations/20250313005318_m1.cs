using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManageDatabase.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerMobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerName);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemCode);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SupplierPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierWebsite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupplierMobile = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierName);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    WarehouseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WarehouseAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WarehouseMangerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.WarehouseName);
                    table.ForeignKey(
                        name: "FK_Warehouses_Employees_WarehouseMangerId",
                        column: x => x.WarehouseMangerId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemMeasureUnits",
                columns: table => new
                {
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMeasureUnits", x => new { x.ItemCode, x.Unit });
                    table.ForeignKey(
                        name: "FK_ItemMeasureUnits_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionPermissions",
                columns: table => new
                {
                    ConsumptionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionPermissions", x => x.ConsumptionID);
                    table.ForeignKey(
                        name: "FK_ConsumptionPermissions_Customers_CustomerName",
                        column: x => x.CustomerName,
                        principalTable: "Customers",
                        principalColumn: "CustomerName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumptionPermissions_Warehouses_WarehouseName",
                        column: x => x.WarehouseName,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemWarehouses",
                columns: table => new
                {
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemWarehouses", x => new { x.ItemCode, x.WarehouseName });
                    table.ForeignKey(
                        name: "FK_ItemWarehouses_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemWarehouses_Warehouses_WarehouseName",
                        column: x => x.WarehouseName,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTransforms",
                columns: table => new
                {
                    TransformID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromWarehouse = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToWarehouse = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransforms", x => x.TransformID);
                    table.ForeignKey(
                        name: "FK_StockTransforms_Suppliers_SupplierName",
                        column: x => x.SupplierName,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransforms_Warehouses_FromWarehouse",
                        column: x => x.FromWarehouse,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransforms_Warehouses_ToWarehouse",
                        column: x => x.ToWarehouse,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplingPermissions",
                columns: table => new
                {
                    SupplingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WarehouseName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupplierName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplingPermissions", x => x.SupplingID);
                    table.ForeignKey(
                        name: "FK_SupplingPermissions_Suppliers_SupplierName",
                        column: x => x.SupplierName,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplingPermissions_Warehouses_WarehouseName",
                        column: x => x.WarehouseName,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionPermissionDetails",
                columns: table => new
                {
                    ConsumptionID = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    ItemAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionPermissionDetails", x => new { x.ConsumptionID, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_ConsumptionPermissionDetails_ConsumptionPermissions_ConsumptionID",
                        column: x => x.ConsumptionID,
                        principalTable: "ConsumptionPermissions",
                        principalColumn: "ConsumptionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConsumptionPermissionDetails_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockTransformDetails",
                columns: table => new
                {
                    TransformID = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    ItemAmount = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTransformDetails", x => new { x.TransformID, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_StockTransformDetails_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockTransformDetails_StockTransforms_TransformID",
                        column: x => x.TransformID,
                        principalTable: "StockTransforms",
                        principalColumn: "TransformID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplingPermissionDetails",
                columns: table => new
                {
                    SupplingID = table.Column<int>(type: "int", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    ItemAmount = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplingPermissionDetails", x => new { x.SupplingID, x.ItemCode });
                    table.ForeignKey(
                        name: "FK_SupplingPermissionDetails_Items_ItemCode",
                        column: x => x.ItemCode,
                        principalTable: "Items",
                        principalColumn: "ItemCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplingPermissionDetails_SupplingPermissions_SupplingID",
                        column: x => x.SupplingID,
                        principalTable: "SupplingPermissions",
                        principalColumn: "SupplingID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionPermissionDetails_ItemCode",
                table: "ConsumptionPermissionDetails",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionPermissions_CustomerName",
                table: "ConsumptionPermissions",
                column: "CustomerName");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionPermissions_WarehouseName",
                table: "ConsumptionPermissions",
                column: "WarehouseName");

            migrationBuilder.CreateIndex(
                name: "IX_ItemWarehouses_WarehouseName",
                table: "ItemWarehouses",
                column: "WarehouseName");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransformDetails_ItemCode",
                table: "StockTransformDetails",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransforms_FromWarehouse",
                table: "StockTransforms",
                column: "FromWarehouse");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransforms_SupplierName",
                table: "StockTransforms",
                column: "SupplierName");

            migrationBuilder.CreateIndex(
                name: "IX_StockTransforms_ToWarehouse",
                table: "StockTransforms",
                column: "ToWarehouse");

            migrationBuilder.CreateIndex(
                name: "IX_SupplingPermissionDetails_ItemCode",
                table: "SupplingPermissionDetails",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_SupplingPermissions_SupplierName",
                table: "SupplingPermissions",
                column: "SupplierName");

            migrationBuilder.CreateIndex(
                name: "IX_SupplingPermissions_WarehouseName",
                table: "SupplingPermissions",
                column: "WarehouseName");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_WarehouseMangerId",
                table: "Warehouses",
                column: "WarehouseMangerId",
                unique: true,
                filter: "[WarehouseMangerId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConsumptionPermissionDetails");

            migrationBuilder.DropTable(
                name: "ItemMeasureUnits");

            migrationBuilder.DropTable(
                name: "ItemWarehouses");

            migrationBuilder.DropTable(
                name: "StockTransformDetails");

            migrationBuilder.DropTable(
                name: "SupplingPermissionDetails");

            migrationBuilder.DropTable(
                name: "ConsumptionPermissions");

            migrationBuilder.DropTable(
                name: "StockTransforms");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "SupplingPermissions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
