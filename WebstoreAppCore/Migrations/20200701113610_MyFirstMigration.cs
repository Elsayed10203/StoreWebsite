using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebStoreAppCore.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessoryTypes",
                columns: table => new
                {
                    AccessoryTypeId = table.Column<int>(nullable: false),
                    AccessoryType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoryTypes", x => x.AccessoryTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Adminshop",
                columns: table => new
                {
                    AdminShopId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: false),
                    ShopName = table.Column<string>(maxLength: 50, nullable: false),
                    ShopEmail = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNo = table.Column<int>(nullable: false),
                    ShopAddress = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adminshop", x => x.AdminShopId);
                });

            migrationBuilder.CreateTable(
                name: "Ads",
                columns: table => new
                {
                    AdID = table.Column<int>(nullable: false),
                    AdPictuer = table.Column<string>(nullable: false),
                    IsDisplay = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(nullable: false),
                    BrandName = table.Column<string>(maxLength: 50, nullable: false),
                    BrandDescription = table.Column<string>(maxLength: 50, nullable: true),
                    BrandLogoPicturePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Brand__DAD4F05EC97550BD", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    CategoryDescription = table.Column<string>(maxLength: 50, nullable: true),
                    CategoryPicturePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__17B6DD06584FA486", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "ErrorTb",
                columns: table => new
                {
                    ErrId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErrMessage = table.Column<string>(nullable: false),
                    ErrDate = table.Column<DateTime>(type: "date", nullable: false),
                    ErrPageName = table.Column<string>(maxLength: 50, nullable: false),
                    ErrLine = table.Column<int>(nullable: true),
                    ErrDetails = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ErrorTb__0A207E202D295610", x => x.ErrId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__9B556A38D3528A01", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "WebUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    UserPassword = table.Column<string>(maxLength: 50, nullable: false, defaultValueSql: "('new')"),
                    UserImagePath = table.Column<string>(maxLength: 75, nullable: true),
                    Address = table.Column<string>(nullable: false),
                    PostCode = table.Column<int>(nullable: false),
                    Phone = table.Column<int>(nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    NoOfAccess = table.Column<int>(nullable: false),
                    CreationDate = table.Column<DateTime>(type: "date", nullable: false),
                    NoOfBlock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WebUser__3213E83F54FFAAAE", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    BrandId = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 50, nullable: true),
                    ProductQuantity = table.Column<int>(nullable: false),
                    ProductPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Discount = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    VendorName = table.Column<string>(maxLength: 50, nullable: true, defaultValueSql: "('admin')"),
                    ProductColor = table.Column<string>(maxLength: 50, nullable: true),
                    ProductRate = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    isOffer = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__042785E57EAF8869", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__Product__BrandId__3B75D760",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Product__CatId__3A81B327",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    OrderDate = table.Column<DateTime>(type: "date", nullable: false),
                    OrderPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    DriverNo = table.Column<int>(nullable: true),
                    DeliveryDate = table.Column<DateTime>(type: "date", nullable: true),
                    IsPaid = table.Column<bool>(nullable: false),
                    IsProductBinEmpty = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PaymentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__C3905BCF795ACD79", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK__orders__PaymentI__5070F446",
                        column: x => x.PaymentId,
                        principalTable: "Payments",
                        principalColumn: "PaymentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__orders__UserId__4F7CD00D",
                        column: x => x.UserId,
                        principalTable: "WebUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserEmails",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersEmailsLogin", x => new { x.UserId, x.Email });
                    table.ForeignKey(
                        name: "FK__UsersEmai__UserI__30F848ED",
                        column: x => x.UserId,
                        principalTable: "WebUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    AccessoryTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessory", x => new { x.ProductId, x.AccessoryTypeId });
                    table.ForeignKey(
                        name: "FK_Accessory_AccessoryTypes",
                        column: x => x.AccessoryTypeId,
                        principalTable: "AccessoryTypes",
                        principalColumn: "AccessoryTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accessory_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LaptopProperties",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ScreenSize = table.Column<string>(maxLength: 50, nullable: true),
                    ScreenType = table.Column<string>(maxLength: 50, nullable: true),
                    Ram = table.Column<string>(maxLength: 50, nullable: true),
                    CameraPropertry = table.Column<string>(maxLength: 50, nullable: true),
                    Battery = table.Column<string>(maxLength: 50, nullable: true),
                    ModeNo = table.Column<string>(maxLength: 50, nullable: true),
                    FingerPrint = table.Column<string>(maxLength: 50, nullable: true),
                    WaterResist = table.Column<string>(maxLength: 50, nullable: true),
                    Processor = table.Column<string>(maxLength: 50, nullable: true),
                    HardType = table.Column<string>(maxLength: 50, nullable: true),
                    HardStorage = table.Column<string>(maxLength: 50, nullable: true),
                    Genaration = table.Column<string>(maxLength: 50, nullable: true),
                    ExtraProperty = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaptopProperty", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__LaptopPro__ProdI__48CFD27E",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MobileProperties",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ScreenSize = table.Column<string>(maxLength: 50, nullable: true),
                    ScreenType = table.Column<string>(maxLength: 50, nullable: true),
                    Ram = table.Column<string>(maxLength: 50, nullable: true),
                    CameraPropertry = table.Column<string>(maxLength: 50, nullable: true),
                    Battery = table.Column<string>(maxLength: 50, nullable: true),
                    ModeNo = table.Column<string>(maxLength: 50, nullable: true),
                    FingerPrint = table.Column<string>(maxLength: 50, nullable: true),
                    WaterResist = table.Column<string>(maxLength: 50, nullable: true),
                    SIM = table.Column<string>(maxLength: 50, nullable: true),
                    OperatingSystem = table.Column<string>(maxLength: 50, nullable: true),
                    Storage = table.Column<string>(maxLength: 50, nullable: true),
                    ExtraProperty = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileProperty", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK__MobilePro__ProdI__46E78A0C",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductPictures",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false),
                    ProductImagePath = table.Column<string>(maxLength: 430, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPictures", x => new { x.ProductId, x.ProductImagePath });
                    table.ForeignKey(
                        name: "FK__ProductPi__ProdI__44FF419A",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFavorites",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavorite", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_UserFavorite_Product",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserFavor__UserI__34C8D9D1",
                        column: x => x.UserId,
                        principalTable: "WebUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProductComments",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    MessageDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    MessageBody = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductComment_1", x => new { x.UserId, x.MessageDate, x.ProductId });
                    table.ForeignKey(
                        name: "FK__UserProdu__ProdI__4222D4EF",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UserProdu__UserI__412EB0B6",
                        column: x => x.UserId,
                        principalTable: "WebUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    SellingPrice = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordersDetails", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK__ordersDet__Order__52593CB8",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__ordersDet__ProdI__534D60F1",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_AccessoryTypeId",
                table: "Accessories",
                column: "AccessoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavorites_ProductId",
                table: "UserFavorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductComments_ProductId",
                table: "UserProductComments",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DropTable(
                name: "Adminshop");

            migrationBuilder.DropTable(
                name: "Ads");

            migrationBuilder.DropTable(
                name: "ErrorTb");

            migrationBuilder.DropTable(
                name: "LaptopProperties");

            migrationBuilder.DropTable(
                name: "MobileProperties");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductPictures");

            migrationBuilder.DropTable(
                name: "UserEmails");

            migrationBuilder.DropTable(
                name: "UserFavorites");

            migrationBuilder.DropTable(
                name: "UserProductComments");

            migrationBuilder.DropTable(
                name: "AccessoryTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "WebUsers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
