using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lab06.Data
{
    public partial class EcommerceContext : DbContext
    {
        public EcommerceContext()
        {
        }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<Attribute> Attributes { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<EmailConfiguration> EmailConfigurations { get; set; } = null!;
        public virtual DbSet<EmailRegistration> EmailRegistrations { get; set; } = null!;
        public virtual DbSet<EmailSignUp> EmailSignUps { get; set; } = null!;
        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; } = null!;
        public virtual DbSet<Gallery> Galleries { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;
        public virtual DbSet<ProductImage> ProductImages { get; set; } = null!;
        public virtual DbSet<ProductRelated> ProductRelateds { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Website> Websites { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI\\MSSQLSERVERTH;Database=Ecommerce;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("Article");

                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(255);

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Articles)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Article_Menu");
            });

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("Attribute");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Customer");

                entity.Property(e => e.Code)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Avatar).IsUnicode(false);

                entity.Property(e => e.Dob).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Otp)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("OTP");

                entity.Property(e => e.Password)
                    .HasMaxLength(124)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<EmailConfiguration>(entity =>
            {
                entity.ToTable("EmailConfiguration");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password).HasMaxLength(100);
            });

            modelBuilder.Entity<EmailRegistration>(entity =>
            {
                entity.ToTable("EmailRegistration");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EmailSignUp>(entity =>
            {
                entity.HasKey(e => e.Email);

                entity.ToTable("EmailSignUp");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Otp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OTP");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.ToTable("EmailTemplate");

                entity.Property(e => e.Bcc)
                    .HasMaxLength(255)
                    .HasColumnName("BCC");

                entity.Property(e => e.Cc)
                    .HasMaxLength(255)
                    .HasColumnName("CC");

                entity.Property(e => e.KeyGuide).HasMaxLength(500);

                entity.Property(e => e.Subject).HasMaxLength(500);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .HasComment("1: WAITING_FOR_REVIEW. \r\n2: WAITING_FOR_APPROVAL. \r\n3: READY_TO_SEND_TO_CUSTOMER. \r\n4: QUOTATION_IS_NEARLY_INVALID.");
            });

            modelBuilder.Entity<Gallery>(entity =>
            {
                entity.ToTable("Gallery");

                entity.Property(e => e.Image).IsUnicode(false);
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.ToTable("Menu");

                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ParentMenuNavigation)
                    .WithMany(p => p.InverseParentMenuNavigation)
                    .HasForeignKey(d => d.ParentMenu)
                    .HasConstraintName("FK_Menu_Menu");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CustomerCode)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Note).HasMaxLength(500);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);

                entity.Property(e => e.Status).HasComment("10: Chờ xác nhận\r\n20: Đã xác nhận\r\n30: Đang vận chuyển\r\n40: Đã giao\r\n50: Đã hủy");

                entity.HasOne(d => d.CustomerCodeNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerCode)
                    .HasConstraintName("FK_Order_Customer");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Attribute).HasMaxLength(500);

                entity.Property(e => e.ProductImage).IsUnicode(false);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderDetail_Order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Alias)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Status).HasComment("10: Đang bán\r\n20: Dừng bán\r\n30: Hết hàng");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Menu");
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.ToTable("ProductAttribute");

                entity.Property(e => e.Value).HasMaxLength(500);

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.AttributeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttribute_Attribute");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductAttribute_Product");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.ToTable("ProductImage");

                entity.Property(e => e.Image).IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductImage_Product");
            });

            modelBuilder.Entity<ProductRelated>(entity =>
            {
                entity.ToTable("ProductRelated");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductRelateds)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductRelated_Product");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("Review");

                entity.Property(e => e.Content).HasMaxLength(500);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Status).HasComment("10: Chờ duyệt\r\n20: Đã duyệt\r\n30: Cập nhật lại - Chờ duyệt");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Review_Product");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserName);

                entity.ToTable("User");

                entity.Property(e => e.UserName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(124)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Website>(entity =>
            {
                entity.ToTable("Website");

                entity.Property(e => e.Address).HasMaxLength(255);

                entity.Property(e => e.Copyright).HasMaxLength(255);

                entity.Property(e => e.Email).HasMaxLength(255);

                entity.Property(e => e.Facebook).HasMaxLength(255);

                entity.Property(e => e.Fax).HasMaxLength(255);

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Logo).IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.Youtube).HasMaxLength(255);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
