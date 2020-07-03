﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebStoreAppCore.Models;

namespace WebStoreAppCore.Migrations
{
    [DbContext(typeof(StoreWebsiteContext))]
    [Migration("20200701113610_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebStoreAppCore.Models.Accessories", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("AccessoryTypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "AccessoryTypeId")
                        .HasName("PK_Accessory");

                    b.HasIndex("AccessoryTypeId");

                    b.ToTable("Accessories");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.AccessoryTypes", b =>
                {
                    b.Property<int>("AccessoryTypeId")
                        .HasColumnType("int");

                    b.Property<string>("AccessoryType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AccessoryTypeId");

                    b.ToTable("AccessoryTypes");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Adminshop", b =>
                {
                    b.Property<int>("AdminShopId")
                        .HasColumnType("int");

                    b.Property<int>("PhoneNo")
                        .HasColumnType("int");

                    b.Property<string>("ShopAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ShopEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ShopName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("AdminShopId");

                    b.ToTable("Adminshop");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Ads", b =>
                {
                    b.Property<int>("AdId")
                        .HasColumnName("AdID")
                        .HasColumnType("int");

                    b.Property<string>("AdPictuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDisplay")
                        .HasColumnType("bit");

                    b.ToTable("Ads");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Brands", b =>
                {
                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("BrandDescription")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("BrandLogoPicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BrandId")
                        .HasName("PK__Brand__DAD4F05EC97550BD");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Categories", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CategoryPicturePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId")
                        .HasName("PK__Category__17B6DD06584FA486");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.ErrorTb", b =>
                {
                    b.Property<int>("ErrId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ErrDate")
                        .HasColumnType("date");

                    b.Property<string>("ErrDetails")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("ErrLine")
                        .HasColumnType("int");

                    b.Property<string>("ErrMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ErrPageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ErrId")
                        .HasName("PK__ErrorTb__0A207E202D295610");

                    b.ToTable("ErrorTb");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.LaptopProperties", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Battery")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CameraPropertry")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ExtraProperty")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FingerPrint")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Genaration")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("HardStorage")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("HardType")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ModeNo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ScreenSize")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ScreenType")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("WaterResist")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProductId")
                        .HasName("PK_LaptopProperty");

                    b.ToTable("LaptopProperties");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.MobileProperties", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Battery")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CameraPropertry")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ExtraProperty")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FingerPrint")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ModeNo")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("OperatingSystem")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ScreenSize")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ScreenType")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Sim")
                        .HasColumnName("SIM")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("WaterResist")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("ProductId")
                        .HasName("PK_MobileProperty");

                    b.ToTable("MobileProperties");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("SellingPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("PK_ordersDetails");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Orders", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DeliveryDate")
                        .HasColumnType("date");

                    b.Property<int?>("DriverNo")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsProductBinEmpty")
                        .HasColumnType("bit");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("date");

                    b.Property<decimal>("OrderPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("OrderId")
                        .HasName("PK__orders__C3905BCF795ACD79");

                    b.HasIndex("PaymentId");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Payments", b =>
                {
                    b.Property<int>("PaymentId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("PaymentId")
                        .HasName("PK__Payment__9B556A38D3528A01");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.ProductPictures", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductImagePath")
                        .HasColumnType("nvarchar(430)")
                        .HasMaxLength(430);

                    b.HasKey("ProductId", "ProductImagePath");

                    b.ToTable("ProductPictures");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Products", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("Discount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<bool>("IsOffer")
                        .HasColumnName("isOffer")
                        .HasColumnType("bit");

                    b.Property<string>("ProductColor")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ProductDescription")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("int");

                    b.Property<int?>("ProductRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("VendorName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("('admin')")
                        .HasMaxLength(50);

                    b.HasKey("ProductId")
                        .HasName("PK__Product__042785E57EAF8869");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.UserEmails", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId", "Email")
                        .HasName("PK_UsersEmailsLogin");

                    b.ToTable("UserEmails");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.UserFavorites", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "ProductId")
                        .HasName("PK_UserFavorite");

                    b.HasIndex("ProductId");

                    b.ToTable("UserFavorites");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.UserProductComments", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("MessageDate")
                        .HasColumnType("datetime");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("MessageBody")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("UserId", "MessageDate", "ProductId")
                        .HasName("PK_UserProductComment_1");

                    b.HasIndex("ProductId");

                    b.ToTable("UserProductComments");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.WebUsers", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("bit");

                    b.Property<int>("NoOfAccess")
                        .HasColumnType("int");

                    b.Property<int>("NoOfBlock")
                        .HasColumnType("int");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("PostCode")
                        .HasColumnType("int");

                    b.Property<string>("UserImagePath")
                        .HasColumnType("nvarchar(75)")
                        .HasMaxLength(75);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)")
                        .HasDefaultValueSql("('new')")
                        .HasMaxLength(50);

                    b.HasKey("UserId")
                        .HasName("PK__WebUser__3213E83F54FFAAAE");

                    b.ToTable("WebUsers");
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Accessories", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.AccessoryTypes", "AccessoryType")
                        .WithMany("Accessories")
                        .HasForeignKey("AccessoryTypeId")
                        .HasConstraintName("FK_Accessory_AccessoryTypes")
                        .IsRequired();

                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithMany("Accessories")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Accessory_Product")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.LaptopProperties", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithOne("LaptopProperties")
                        .HasForeignKey("WebStoreAppCore.Models.LaptopProperties", "ProductId")
                        .HasConstraintName("FK__LaptopPro__ProdI__48CFD27E")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.MobileProperties", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithOne("MobileProperties")
                        .HasForeignKey("WebStoreAppCore.Models.MobileProperties", "ProductId")
                        .HasConstraintName("FK__MobilePro__ProdI__46E78A0C")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.OrderDetails", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Orders", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("FK__ordersDet__Order__52593CB8")
                        .IsRequired();

                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ordersDet__ProdI__534D60F1")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Orders", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Payments", "Payment")
                        .WithMany("Orders")
                        .HasForeignKey("PaymentId")
                        .HasConstraintName("FK__orders__PaymentI__5070F446")
                        .IsRequired();

                    b.HasOne("WebStoreAppCore.Models.WebUsers", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__orders__UserId__4F7CD00D")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.ProductPictures", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithMany("ProductPictures")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__ProductPi__ProdI__44FF419A")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.Products", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Brands", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK__Product__BrandId__3B75D760")
                        .IsRequired();

                    b.HasOne("WebStoreAppCore.Models.Categories", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK__Product__CatId__3A81B327")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.UserEmails", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.WebUsers", "User")
                        .WithMany("UserEmails")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UsersEmai__UserI__30F848ED")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.UserFavorites", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithMany("UserFavorites")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_UserFavorite_Product")
                        .IsRequired();

                    b.HasOne("WebStoreAppCore.Models.WebUsers", "User")
                        .WithMany("UserFavorites")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UserFavor__UserI__34C8D9D1")
                        .IsRequired();
                });

            modelBuilder.Entity("WebStoreAppCore.Models.UserProductComments", b =>
                {
                    b.HasOne("WebStoreAppCore.Models.Products", "Product")
                        .WithMany("UserProductComments")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK__UserProdu__ProdI__4222D4EF")
                        .IsRequired();

                    b.HasOne("WebStoreAppCore.Models.WebUsers", "User")
                        .WithMany("UserProductComments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__UserProdu__UserI__412EB0B6")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
