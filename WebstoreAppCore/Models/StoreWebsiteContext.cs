using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebstoreAppCore.Models
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

        public virtual DbSet<Adminshop> Adminshop { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<ErrorTb> ErrorTb { get; set; }
        public virtual DbSet<LaptopProperty> LaptopProperty { get; set; }
        public virtual DbSet<MobileProperty> MobileProperty { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrdersDetails> OrdersDetails { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductPictures> ProductPictures { get; set; }
        public virtual DbSet<UserFavorite> UserFavorite { get; set; }
        public virtual DbSet<UserProductComment> UserProductComment { get; set; }
        public virtual DbSet<UsersEmailsLogin> UsersEmailsLogin { get; set; }
        public virtual DbSet<WebUser> WebUser { get; set; }

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
            modelBuilder.Entity<Adminshop>(entity =>
            {
                entity.HasKey(e => e.AddminId)
                    .HasName("PK__Adminsho__C0708CC43996A7C6");

                entity.Property(e => e.AddminId).ValueGeneratedNever();

                entity.Property(e => e.AdmPass).HasMaxLength(50);

                entity.Property(e => e.AdmUserName).HasMaxLength(50);

                entity.Property(e => e.ShopAddrase).HasMaxLength(50);

                entity.Property(e => e.ShopEmail).HasMaxLength(50);

                entity.Property(e => e.ShopName).HasMaxLength(50);
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.BrandDescrp).HasMaxLength(50);

                entity.Property(e => e.BrandLogoPicturePath).HasMaxLength(75);

                entity.Property(e => e.BrandName).HasMaxLength(50);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PK__Category__17B6DD06584FA486");

                entity.Property(e => e.CatId)
                    .HasColumnName("catId")
                    .ValueGeneratedNever();

                entity.Property(e => e.CatDescrp).HasMaxLength(50);

                entity.Property(e => e.CatName).HasMaxLength(50);

                entity.Property(e => e.CatPicturePath).HasMaxLength(75);
            });

            modelBuilder.Entity<ErrorTb>(entity =>
            {
                entity.HasKey(e => e.ErrId)
                    .HasName("PK__ErrorTb__0A207E202D295610");

                entity.Property(e => e.ErrorDate).HasColumnType("date");

                entity.Property(e => e.ErrorDetails).HasMaxLength(50);

                entity.Property(e => e.PageName).HasMaxLength(50);
            });

            modelBuilder.Entity<LaptopProperty>(entity =>
            {
                entity.HasNoKey();

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

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__LaptopPro__ProdI__48CFD27E");
            });

            modelBuilder.Entity<MobileProperty>(entity =>
            {
                entity.HasNoKey();

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

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__MobilePro__ProdI__46E78A0C");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__orders__C3905BCF795ACD79");

                entity.ToTable("orders");

                entity.Property(e => e.OrderId).ValueGeneratedNever();

                entity.Property(e => e.DriverDate).HasColumnType("date");

                entity.Property(e => e.EmptyProductBin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('f')");

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderPrice).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.Paid)
                    .HasColumnName("paid")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('f')");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentId)
                    .HasConstraintName("FK__orders__PaymentI__5070F446");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__orders__UserId__4F7CD00D");
            });

            modelBuilder.Entity<OrdersDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ordersDetails");

                entity.Property(e => e.ProdPriceSale).HasColumnType("decimal(10, 4)");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__ordersDet__Order__52593CB8");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__ordersDet__ProdI__534D60F1");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.PaymentType).HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PK__Product__042785E57EAF8869");

                entity.Property(e => e.ProdId).ValueGeneratedNever();

                entity.Property(e => e.Discound).HasDefaultValueSql("((0))");

                entity.Property(e => e.ProdColor).HasMaxLength(50);

                entity.Property(e => e.ProdDescrp)
                    .HasColumnName("prodDescrp")
                    .HasMaxLength(50);

                entity.Property(e => e.ProdName)
                    .HasColumnName("prodName")
                    .HasMaxLength(50);

                entity.Property(e => e.Prodprice)
                    .HasColumnName("prodprice")
                    .HasColumnType("decimal(10, 4)");

                entity.Property(e => e.ProductAvailableLocation)
                    .HasColumnName("productAvailableLocation")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorName)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('admin')");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Product__BrandId__3B75D760");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK__Product__CatId__3A81B327");
            });

            modelBuilder.Entity<ProductPictures>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProdImagePath).HasMaxLength(75);

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__ProductPi__ProdI__44FF419A");
            });

            modelBuilder.Entity<UserFavorite>(entity =>
            {
                entity.HasNoKey();

                entity.HasOne(d => d.FavoriteCatagNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.FavoriteCatag)
                    .HasConstraintName("FK__UserFavor__Favor__35BCFE0A");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserFavor__UserI__34C8D9D1");
            });

            modelBuilder.Entity<UserProductComment>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MessageDate)
                    .HasColumnName("messageDate")
                    .HasColumnType("date");

                entity.Property(e => e.MessgeBody)
                    .HasColumnName("messgeBody")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__UserProdu__ProdI__4222D4EF");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserProdu__UserI__412EB0B6");
            });

            modelBuilder.Entity<UsersEmailsLogin>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UsersEmai__UserI__30F848ED");
            });

            modelBuilder.Entity<WebUser>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountSatet)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('New')");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.NoOfAccess).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.UserImagePath).HasMaxLength(75);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);

                entity.Property(e => e.Userpass)
                    .HasColumnName("userpass")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('new')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
