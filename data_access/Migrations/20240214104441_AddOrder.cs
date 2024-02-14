using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class AddOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryContactInfos_Advertisements_AdvertisementId",
                table: "DeliveryContactInfos");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryContactInfos_AdvertisementId",
                table: "DeliveryContactInfos");

            migrationBuilder.DropColumn(
                name: "AdvertisementId",
                table: "DeliveryContactInfos");

            migrationBuilder.DropColumn(
                name: "CheckoutDate",
                table: "DeliveryContactInfos");

            migrationBuilder.AlterColumn<string>(
                name: "PostOffice",
                table: "DeliveryContactInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryContactInfoId",
                table: "Advertisements",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    DeliveryContactInfoId = table.Column<int>(type: "int", nullable: false),
                    CheckoutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_DeliveryContactInfos_DeliveryContactInfoId",
                        column: x => x.DeliveryContactInfoId,
                        principalTable: "DeliveryContactInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OrderStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Processing" },
                    { 3, "Shipped" },
                    { 4, "Delivered" },
                    { 5, "Pending Payment" },
                    { 6, "Canceled" },
                    { 7, "Refused" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_DeliveryContactInfoId",
                table: "Advertisements",
                column: "DeliveryContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AdvertisementId",
                table: "Order",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeliveryContactInfoId",
                table: "Order",
                column: "DeliveryContactInfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusId",
                table: "Order",
                column: "OrderStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Advertisements_DeliveryContactInfos_DeliveryContactInfoId",
                table: "Advertisements",
                column: "DeliveryContactInfoId",
                principalTable: "DeliveryContactInfos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Advertisements_DeliveryContactInfos_DeliveryContactInfoId",
                table: "Advertisements");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropIndex(
                name: "IX_Advertisements_DeliveryContactInfoId",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "DeliveryContactInfoId",
                table: "Advertisements");

            migrationBuilder.AlterColumn<string>(
                name: "PostOffice",
                table: "DeliveryContactInfos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdvertisementId",
                table: "DeliveryContactInfos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CheckoutDate",
                table: "DeliveryContactInfos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContactInfos_AdvertisementId",
                table: "DeliveryContactInfos",
                column: "AdvertisementId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryContactInfos_Advertisements_AdvertisementId",
                table: "DeliveryContactInfos",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
