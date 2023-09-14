using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopsRUsDiscounts.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CreaatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DiscountRatio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CustomerType = table.Column<int>(type: "int", nullable: false),
                    CreaatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DicountedPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreaatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreaatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreaatedDate", "CustomerType", "Email", "FullName", "IsActive", "IsDelete", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("07f93dac-1223-43e1-a8d2-3d2f67340b85"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5120), 1, "b@a.com", "veli eren", true, false, null, null },
                    { new Guid("5abae814-6113-417b-aec1-8afeb8dc01e1"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5090), 0, "a@a.com", "mustafa eren", true, false, null, null },
                    { new Guid("af60dea2-0ee8-4be6-93df-7e034052a108"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5100), 2, "b@a.com", "ali eren", true, false, null, null },
                    { new Guid("db94b670-8846-439c-b5ba-9cad90e66ffd"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5130), 3, "b@a.com", "aayşe eren", true, false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "CreaatedDate", "CustomerType", "DiscountRatio", "IsActive", "IsDelete", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("6e772212-bec4-4f5b-a47f-4b66ee1967d4"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5240), 1, 30m, true, false, null },
                    { new Guid("90ded744-5c1b-469f-b7da-93eea712e8d2"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5250), 3, 5m, true, false, null },
                    { new Guid("e3edac69-1cb3-4c11-aad6-5feb903793aa"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5210), 0, 0m, true, false, null },
                    { new Guid("ea695148-6b68-46c2-9697-ccf8f54a1bd2"), new DateTime(2023, 9, 14, 13, 41, 4, 912, DateTimeKind.Local).AddTicks(5220), 2, 10m, true, false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_CustomerType",
                table: "Discounts",
                column: "CustomerType",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_OrderId",
                table: "Invoices",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
