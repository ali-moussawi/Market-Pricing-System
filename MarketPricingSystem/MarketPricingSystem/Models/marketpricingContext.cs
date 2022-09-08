using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace MarketPricingSystem.Models
{
    public partial class marketpricingContext : DbContext
    {
        public marketpricingContext()
        {
        }

        public marketpricingContext(DbContextOptions<marketpricingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Loginlogs> Loginlogs { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<Productprices> Productprices { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Rolepermissions> Rolepermissions { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Supermarket> Supermarket { get; set; }
        public virtual DbSet<Usergmails> Usergmails { get; set; }
        public virtual DbSet<Userpermissions> Userpermissions { get; set; }
        public virtual DbSet<Userroles> Userroles { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Usersphonenumber> Usersphonenumber { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123;database=marketpricing");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("categories");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("categoryName_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Loginlogs>(entity =>
            {
                entity.HasKey(e => e.LogId)
                    .HasName("PRIMARY");

                entity.ToTable("loginlogs");

                entity.Property(e => e.LoginDate).HasColumnType("date");

                entity.Property(e => e.UserGmail)
                    .IsRequired()
                    .HasColumnName("userGmail")
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("PRIMARY");

                entity.ToTable("permissions");

                entity.Property(e => e.PermissionName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Productprices>(entity =>
            {
                entity.HasKey(e => new { e.Price, e.Date })
                    .HasName("PRIMARY");

                entity.ToTable("productprices");

                entity.HasIndex(e => e.ProductId)
                    .HasName("prid_idx");

                entity.HasIndex(e => e.Supermarketid)
                    .HasName("spid_idx");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Supermarketid).HasColumnName("supermarketid");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Productprices)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("prid");

                entity.HasOne(d => d.Supermarket)
                    .WithMany(p => p.Productprices)
                    .HasForeignKey(d => d.Supermarketid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spid");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PRIMARY");

                entity.ToTable("products");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("ctgr_idx");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.ProductDescription)
                    .HasColumnName("productDescription")
                    .HasMaxLength(255);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("productName")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("ctgr");
            });

            modelBuilder.Entity<Rolepermissions>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.PermissionId })
                    .HasName("PRIMARY");

                entity.ToTable("rolepermissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("forg2_idx");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Rolepermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("forg2");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Rolepermissions)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("forg1");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("roles");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Supermarket>(entity =>
            {
                entity.ToTable("supermarket");

                entity.Property(e => e.SupermarketId).HasColumnName("supermarketId");

                entity.Property(e => e.SupermarketDescription)
                    .HasColumnName("supermarketDescription")
                    .HasMaxLength(255);

                entity.Property(e => e.SupermarketName)
                    .IsRequired()
                    .HasColumnName("supermarketName")
                    .HasMaxLength(45);

                entity.Property(e => e.SupermarketRegion)
                    .IsRequired()
                    .HasColumnName("supermarketRegion")
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Usergmails>(entity =>
            {
                entity.HasKey(e => e.UserGmail)
                    .HasName("PRIMARY");

                entity.ToTable("usergmails");

                entity.HasIndex(e => e.UserId)
                    .HasName("gm_idx");

                entity.Property(e => e.UserGmail).HasMaxLength(55);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(55);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usergmails)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("gm");
            });

            modelBuilder.Entity<Userpermissions>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.PermissionId })
                    .HasName("PRIMARY");

                entity.ToTable("userpermissions");

                entity.HasIndex(e => e.PermissionId)
                    .HasName("fgn2_idx");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.Userpermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("fgn2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userpermissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fgn1");
            });

            modelBuilder.Entity<Userroles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PRIMARY");

                entity.ToTable("userroles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("frg2_idx");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Userroles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("frg2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userroles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("frg1");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("users");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(55);
            });

            modelBuilder.Entity<Usersphonenumber>(entity =>
            {
                entity.HasKey(e => e.PhoneNumber)
                    .HasName("PRIMARY");

                entity.ToTable("usersphonenumber");

                entity.HasIndex(e => e.SuperMarketId)
                    .HasName("usf2_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("usf1_idx");

                entity.Property(e => e.PhoneNumber).HasMaxLength(45);

                entity.HasOne(d => d.SuperMarket)
                    .WithMany(p => p.Usersphonenumber)
                    .HasForeignKey(d => d.SuperMarketId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("usf2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Usersphonenumber)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("usf1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
