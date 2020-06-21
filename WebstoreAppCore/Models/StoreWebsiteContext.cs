using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebStoreAppCore.Models
{
    public partial class StoreWebsiteContext : DbContext
    {
        public StoreWebsiteContext()
        {
        }

        public StoreWebsiteContext(DbContextOptions<StoreWebsiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accessories> Accessories { get; set; }
        public virtual DbSet<AccessoryTypes> AccessoryTypes { get; set; }
        public virtual DbSet<Adminshop> Adminshop { get; set; }
        public virtual DbSet<Ads> Ads { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ErrorTb> ErrorTb { get; set; }
        public virtual DbSet<LaptopProperties> LaptopProperties { get; set; }
        public virtual DbSet<MobileProperties> MobileProperties { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<ProductPictures> ProductPictures { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<UserEmails> UserEmails { get; set; }
        public virtual DbSet<UserFavorites> UserFavorites { get; set; }
        public virtual DbSet<UserProductComments> UserProductComments { get; set; }
        public virtual DbSet<WebUsers> WebUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=StoreWebsite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accessories>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.AccessoryTypeId })
                    .HasName("PK_Accessory");

                entity.HasOne(d => d.AccessoryType)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.AccessoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accessory_AccessoryTypes");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Accessories)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accessory_Product");
            });

            modelBuilder.Entity<AccessoryTypes>(entity =>
            {
                entity.HasKey(e => e.AccessoryTypeId);

                entity.Property(e => e.AccessoryTypeId).ValueGeneratedNever();

                entity.Property(e => e.AccessoryType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Adminshop>(entity =>
            {
                entity.Property(e => e.AdminShopId).ValueGeneratedNever();

                entity.Property(e => e.ShopAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShopEmail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShopName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Ads>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AdId).HasColumnName("AdID");

                entity.Property(e => e.AdPictuer).IsRequired();
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK__Brand__DAD4F05EC97550BD");

                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.BrandDescription).HasMaxLength(50);

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Category__17B6DD06584FA486");

                entity.Property(e => e.CategoryId).ValueGeneratedNever();

                entity.Property(e => e.CategoryDescription).HasMaxLength(50);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ErrorTb>(entity =>
            {
                entity.HasKey(e => e.ErrId)
                    .HasName("PK__ErrorTb__0A207E202D295610");

                entity.Property(e => e.ErrDate).HasColumnType("date");

                entity.Property(e => e.ErrDetails).HasMaxLength(50);

                entity.Property(e => e.ErrMessage).IsRequired();

                entity.Property(e => e.ErrPageName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<LaptopProperties>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_LaptopProperty");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Battery).HasMaxLength(50);

                entity.Property(e => e.CameraPropertry).HasMaxLength(50);

                entity.Property(e => e.ExtraProperty).HasMaxLength(50);

                entity.Property(e => e.FingerPrint).HasMaxLength(50);

                entity.Property(e => e.Genaration).HasMaxLength(50);

                entity.Property(e => e.HardStorage).HasMaxLength(50);

                entity.Property(e => e.HardType).HasMaxLength(50);

                entity.Property(e => e.ModeNo).HasMaxLength(50);

                entity.Property(e => e.Processor).HasMaxLength(50);

                entity.Property(e => e.Ram).HasMaxLength(50);

                entity.Property(e => e.ScreenSize).HasMaxLength(50);

                entity.Property(e => e.ScreenType).HasMaxLength(50);

                entity.Property(e => e.WaterResist).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.LaptopProperties)
                    .HasForeignKey<LaptopProperties>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LaptopPro__ProdI__48CFD27E");
            });

            modelBuilder.Entity<MobileProperties>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_MobileProperty");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Battery).HasMaxLength(50);

                entity.Property(e => e.CameraPropertry).HasMaxLength(50);

                entity.Property(e => e.ExtraProperty).HasMaxLength(50);

                entity.Property(e => e.FingerPrint).HasMaxLength(50);

                entity.Property(e => e.ModeNo).HasMaxLength(50);

                entity.Property(e => e.OperatingSystem).HasMaxLength(50);

                entity.Property(e => e.Ram).HasMaxLength(50);

                entity.Property(e => e.ScreenSize).HasMaxLength(50);

                entity.Property(e => e.ScreenType).HasMaxLength(50);

                entity.Property(e => e.Sim)
                    .HasColumnName("SIM")
                    .HasMaxLength(50);

                entity.Property(e => e.Storage).HasMaxLength(50);

                entity.Property(e => e.WaterResist).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithOne(p => p.MobileProperties)
                    .HasForeignKey<MobileProperties>(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MobilePro__ProdI__46E78A0C");
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.ProductId })
                    .HasName("PK_ordersDetails");

                entity.Property(e => e.SellingPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ordersDet__Order__52593CB8");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ordersDet__ProdI__534D60F1");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__orders__C3905BCF795ACD79");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__PaymentI__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__orders__UserId__4F7CD00D");
            });

            modelBuilder.Entity<Payments>(entity =>
            {
                entity.HasKey(e => e.PaymentId)
                    .HasName("PK__Payment__9B556A38D3528A01");

                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.PaymentType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<ProductPictures>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.ProductImagePath });

                entity.Property(e => e.ProductImagePath).HasMaxLength(430);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPictures)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ProductPi__ProdI__44FF419A");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Product__042785E57EAF8869");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.Discount).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsOffer).HasColumnName("isOffer");

                entity.Property(e => e.ProductColor).HasMaxLength(50);

                entity.Property(e => e.ProductDescription).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.VendorName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('admin')");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__BrandId__3B75D760");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__CatId__3A81B327");
            });

            modelBuilder.Entity<UserEmails>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.Email })
                    .HasName("PK_UsersEmailsLogin");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserEmails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UsersEmai__UserI__30F848ED");
            });

            modelBuilder.Entity<UserFavorites>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProductId })
                    .HasName("PK_UserFavorite");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserFavorite_Product");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserFavorites)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserFavor__UserI__34C8D9D1");
            });

            modelBuilder.Entity<UserProductComments>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.MessageDate, e.ProductId })
                    .HasName("PK_UserProductComment_1");

                entity.Property(e => e.MessageDate).HasColumnType("datetime");

                entity.Property(e => e.MessageBody)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.UserProductComments)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserProdu__ProdI__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserProductComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserProdu__UserI__412EB0B6");
            });

            modelBuilder.Entity<WebUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__WebUser__3213E83F54FFAAAE");

                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.UserImagePath).HasMaxLength(75);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('new')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
