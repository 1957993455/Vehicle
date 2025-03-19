using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace Vehicle.App.Migrations
{
    /// <inheritdoc />
    public partial class add_business : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "车辆ID"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "订单状态"),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "客户ID"),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "订单总金额"),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false, comment: "支付方式"),
                    PaymentStatus = table.Column<int>(type: "int", nullable: false, comment: "支付状态"),
                    Remarks = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "订单备注"),
                    PickupTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "预约取车时间"),
                    ReturnTime = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "预约还车时间"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                },
                comment: "订单信息");

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "门店名称"),
                    StoreCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, comment: "门店编码"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "省"),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "市"),
                    Address_District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "区"),
                    Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "街道"),
                    Address_Detail = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false, comment: "详细地址"),
                    Location_Longitude = table.Column<double>(type: "float(9)", precision: 9, scale: 6, nullable: false, comment: "经度"),
                    Location_Latitude = table.Column<double>(type: "float(8)", precision: 8, scale: 6, nullable: false, comment: "纬度"),
                    BusinessHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "门店状态"),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "所属区域ID"),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "店长用户ID"),
                    Tags = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "门店标签"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true, comment: "门店描述"),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                },
                comment: "门店信息表");

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VIN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brand = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    LicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EngineType = table.Column<int>(type: "int", nullable: false),
                    TransmissionType = table.Column<int>(type: "int", nullable: false),
                    FuelType = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address_Province = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_District = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address_Detail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "订单ID"),
                    ItemName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "项目名称"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "单价"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "数量"),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "小计金额"),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, defaultValue: 0m, comment: "折扣金额"),
                    ActualAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "实际金额"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "描述"),
                    Sort = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "排序"),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "订单明细");

            migrationBuilder.CreateTable(
                name: "VehicleAccidentRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccidentDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "事故发生日期"),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false, comment: "事故描述"),
                    RepairCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "维修费用"),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "所属车辆ID"),
                    AccidentLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceCompany = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsurancePolicyNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimStatus = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverLicenseType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HandlingDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverViolation = table.Column<bool>(type: "bit", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VehicleAggregateRootId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleAccidentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleAccidentRecords_Vehicle_VehicleAggregateRootId",
                        column: x => x.VehicleAggregateRootId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                },
                comment: "车辆事故记录");

            migrationBuilder.CreateTable(
                name: "VehicleMaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "维护项目描述"),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "维护费用"),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleMaintenanceRecords_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "车辆维护记录");

            migrationBuilder.CreateTable(
                name: "VehiclePurchaseRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "购买日期"),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "购买价格"),
                    SupplierName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "供应商名称"),
                    SupplierPhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false, comment: "供应商电话"),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "支付方式"),
                    Remarks = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "备注"),
                    VehicleAggregateRootId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePurchaseRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePurchaseRecords_Vehicle_VehicleAggregateRootId",
                        column: x => x.VehicleAggregateRootId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                },
                comment: "车辆购买记录");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId_Sort",
                table: "OrderDetails",
                columns: new[] { "OrderId", "Sort" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId_Status",
                table: "Orders",
                columns: new[] { "CustomerId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentStatus",
                table: "Orders",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PickupTime",
                table: "Orders",
                column: "PickupTime");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Status",
                table: "Orders",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VehicleId",
                table: "Orders",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VehicleId_Status",
                table: "Orders",
                columns: new[] { "VehicleId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_Location",
                table: "Stores",
                columns: new[] { "Location_Longitude", "Location_Latitude" });

            migrationBuilder.CreateIndex(
                name: "IX_Store_RegionId",
                table: "Stores",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "UK_Store_Code",
                table: "Stores",
                column: "StoreCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccidentRecord_Date",
                table: "VehicleAccidentRecords",
                column: "AccidentDate");

            migrationBuilder.CreateIndex(
                name: "IX_AccidentRecord_VehicleId",
                table: "VehicleAccidentRecords",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleAccidentRecords_VehicleAggregateRootId",
                table: "VehicleAccidentRecords",
                column: "VehicleAggregateRootId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecord_CreationTime",
                table: "VehicleMaintenanceRecords",
                column: "CreationTime");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecord_VehicleId",
                table: "VehicleMaintenanceRecords",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePurchaseRecord_VehicleId",
                table: "VehiclePurchaseRecords",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePurchaseRecords_VehicleAggregateRootId",
                table: "VehiclePurchaseRecords",
                column: "VehicleAggregateRootId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "VehicleAccidentRecords");

            migrationBuilder.DropTable(
                name: "VehicleMaintenanceRecords");

            migrationBuilder.DropTable(
                name: "VehiclePurchaseRecords");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
