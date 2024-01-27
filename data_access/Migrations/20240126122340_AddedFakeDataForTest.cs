using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace data_access.Migrations
{
    /// <inheritdoc />
    public partial class AddedFakeDataForTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryHomeAdrdesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Build = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Appartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtraInfoForCourier = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryHomeAdrdesses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.CheckConstraint("CK_Entity_Email", "Email LIKE '%_@_%._%'");
                });

            migrationBuilder.CreateTable(
                name: "DeliveryContactInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryCompanyId = table.Column<int>(type: "int", nullable: false),
                    DeliveryHomeAddressId = table.Column<int>(type: "int", nullable: true),
                    DeliveryHomeAdrdessId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOffice = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryContactInfos_DeliveryCompanies_DeliveryCompanyId",
                        column: x => x.DeliveryCompanyId,
                        principalTable: "DeliveryCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryContactInfos_DeliveryHomeAdrdesses_DeliveryHomeAdrdessId",
                        column: x => x.DeliveryHomeAdrdessId,
                        principalTable: "DeliveryHomeAdrdesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Advertisements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    DeliveryContactInfoId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AdvertisementStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisements_AdvertisementStatuses_AdvertisementStatusId",
                        column: x => x.AdvertisementStatusId,
                        principalTable: "AdvertisementStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisements_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Advertisements_DeliveryContactInfos_DeliveryContactInfoId",
                        column: x => x.DeliveryContactInfoId,
                        principalTable: "DeliveryContactInfos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Advertisements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisePictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdvertisementId = table.Column<int>(type: "int", nullable: false),
                    IsMainPicture = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdvertisePictures_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AdvertisementStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "New" },
                    { 2, "Active" },
                    { 3, "Unactive" },
                    { 4, "Deleted" },
                    { 5, "Archive" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 1, "Child wares", null },
                    { 2, "Cars", null },
                    { 3, "Transports parts", null },
                    { 4, "Jobs", null },
                    { 5, "Animals", null },
                    { 6, "Home and garden", null },
                    { 7, "Electronics", null },
                    { 8, "Business and commerce", null },
                    { 9, "Rents and hires", null },
                    { 10, "Fashion & Style", null },
                    { 11, "Hobbies, leisure and sports", null }
                });

            migrationBuilder.InsertData(
                table: "DeliveryCompanies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "UkrPoshta" },
                    { 2, "NovaPoshta" },
                    { 3, "MeestExpress" },
                    { 4, "Delivery" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "johndoe@gmail.com", "John", "Doe", "0972463461" },
                    { 2, "valterscott@gmail.com", "Valter", "Scott", "0954285352" },
                    { 3, "danielgreen@gmail.com", "Daniel", "Green", "0735520395" },
                    { 4, "abraham@gmail.com", "Abraham", "Eddison", "0994725481" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { 12, "Phones and accessories", 7 },
                    { 13, "Audio", 7 },
                    { 14, "Home appliances", 7 },
                    { 15, "Accessories and components", 7 },
                    { 16, "Computers and components", 7 },
                    { 17, "Games and consoles", 7 },
                    { 18, "Appliance for kitchen", 7 },
                    { 19, "Other appliance", 7 },
                    { 20, "Photo and video", 7 },
                    { 21, "Tablets / Ebooks", 7 },
                    { 22, "HVAC equipment", 7 },
                    { 23, "Repair of equipment", 7 },
                    { 24, "TV / Video", 7 },
                    { 25, "Laptops and accessories", 7 }
                });

            migrationBuilder.InsertData(
                table: "Advertisements",
                columns: new[] { "Id", "AdvertisementStatusId", "CategoryId", "City", "DeliveryContactInfoId", "Description", "Price", "Title", "UserId" },
                values: new object[] { 1, 2, 12, "Kyiv", null, "New phone with waranty", 67399m, "iPhone 13 Pro Max 512Gb", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_AdvertisementStatusId",
                table: "Advertisements",
                column: "AdvertisementStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_CategoryId",
                table: "Advertisements",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_DeliveryContactInfoId",
                table: "Advertisements",
                column: "DeliveryContactInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisements_UserId",
                table: "Advertisements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AdvertisePictures_AdvertisementId",
                table: "AdvertisePictures",
                column: "AdvertisementId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContactInfos_DeliveryCompanyId",
                table: "DeliveryContactInfos",
                column: "DeliveryCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryContactInfos_DeliveryHomeAdrdessId",
                table: "DeliveryContactInfos",
                column: "DeliveryHomeAdrdessId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisePictures");

            migrationBuilder.DropTable(
                name: "Advertisements");

            migrationBuilder.DropTable(
                name: "AdvertisementStatuses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DeliveryContactInfos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "DeliveryCompanies");

            migrationBuilder.DropTable(
                name: "DeliveryHomeAdrdesses");
        }
    }
}
