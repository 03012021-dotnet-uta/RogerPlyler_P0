using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PizzaBox.Domain.Models
{
   public partial class PizzaBoxContext : DbContext
    {
        public PizzaBoxContext()
        {
        }

        public PizzaBoxContext(DbContextOptions<PizzaBoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acrust> Acrusts { get; set; }
        public virtual DbSet<Acustomer> Acustomers { get; set; }
        public virtual DbSet<Aorder> Aorders { get; set; }
        public virtual DbSet<AorderedPizza> AorderedPizzas { get; set; }
        public virtual DbSet<Apizza> Apizzas { get; set; }
        public virtual DbSet<Asize> Asizes { get; set; }
        public virtual DbSet<Astore> Astores { get; set; }
        public virtual DbSet<Atopping> Atoppings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=PizzaBox;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Acrust>(entity =>
            {
                entity.ToTable("ACrust");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CrustName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CrustPrice).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Acustomer>(entity =>
            {
                entity.ToTable("ACustomer");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Aorder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__AOrder__C3905BAFDF06D59D");

                entity.ToTable("AOrder");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("OrderID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.StoreId).HasColumnName("StoreID");

                entity.Property(e => e.TimeOrdered).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__AOrder__Customer__44FF419A");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Aorders)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AOrder__StoreID__440B1D61");
            });

            modelBuilder.Entity<AorderedPizza>(entity =>
            {
                entity.ToTable("AOrderedPizza");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.CrustNavigation)
                    .WithMany(p => p.AorderedPizzaCrustNavigations)
                    .HasForeignKey(d => d.Crust)
                    .HasConstraintName("FK__AOrderedP__Crust__4E88ABD4");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.AorderedPizzas)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AOrderedP__Order__47DBAE45");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.AorderedPizzaSizeNavigations)
                    .HasForeignKey(d => d.Size)
                    .HasConstraintName("FK__AOrderedPi__Size__4D94879B");

                entity.HasOne(d => d.Topping1Navigation)
                    .WithMany(p => p.AorderedPizzaTopping1Navigations)
                    .HasForeignKey(d => d.Topping1)
                    .HasConstraintName("FK__AOrderedP__Toppi__48CFD27E");

                entity.HasOne(d => d.Topping2Navigation)
                    .WithMany(p => p.AorderedPizzaTopping2Navigations)
                    .HasForeignKey(d => d.Topping2)
                    .HasConstraintName("FK__AOrderedP__Toppi__49C3F6B7");

                entity.HasOne(d => d.Topping3Navigation)
                    .WithMany(p => p.AorderedPizzaTopping3Navigations)
                    .HasForeignKey(d => d.Topping3)
                    .HasConstraintName("FK__AOrderedP__Toppi__4AB81AF0");

                entity.HasOne(d => d.Topping4Navigation)
                    .WithMany(p => p.AorderedPizzaTopping4Navigations)
                    .HasForeignKey(d => d.Topping4)
                    .HasConstraintName("FK__AOrderedP__Toppi__4BAC3F29");

                entity.HasOne(d => d.Topping5Navigation)
                    .WithMany(p => p.AorderedPizzaTopping5Navigations)
                    .HasForeignKey(d => d.Topping5)
                    .HasConstraintName("FK__AOrderedP__Toppi__4CA06362");
            });

            modelBuilder.Entity<Apizza>(entity =>
            {
                entity.ToTable("APizza");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.PizzaName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.CrustNavigation)
                    .WithMany(p => p.ApizzaCrustNavigations)
                    .HasForeignKey(d => d.Crust)
                    .HasConstraintName("FK__APizza__Crust__1FCDBCEB");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.ApizzaSizeNavigations)
                    .HasForeignKey(d => d.Size)
                    .HasConstraintName("FK__APizza__Size__1ED998B2");

                entity.HasOne(d => d.Topping1Navigation)
                    .WithMany(p => p.ApizzaTopping1Navigations)
                    .HasForeignKey(d => d.Topping1)
                    .HasConstraintName("FK__APizza__Topping1__1A14E395");

                entity.HasOne(d => d.Topping2Navigation)
                    .WithMany(p => p.ApizzaTopping2Navigations)
                    .HasForeignKey(d => d.Topping2)
                    .HasConstraintName("FK__APizza__Topping2__1B0907CE");

                entity.HasOne(d => d.Topping3Navigation)
                    .WithMany(p => p.ApizzaTopping3Navigations)
                    .HasForeignKey(d => d.Topping3)
                    .HasConstraintName("FK__APizza__Topping3__1BFD2C07");

                entity.HasOne(d => d.Topping4Navigation)
                    .WithMany(p => p.ApizzaTopping4Navigations)
                    .HasForeignKey(d => d.Topping4)
                    .HasConstraintName("FK__APizza__Topping4__1CF15040");

                entity.HasOne(d => d.Topping5Navigation)
                    .WithMany(p => p.ApizzaTopping5Navigations)
                    .HasForeignKey(d => d.Topping5)
                    .HasConstraintName("FK__APizza__Topping5__1DE57479");
            });

            modelBuilder.Entity<Asize>(entity =>
            {
                entity.ToTable("ASize");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SizePrice).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<Astore>(entity =>
            {
                entity.ToTable("AStore");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.StoreName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Atopping>(entity =>
            {
                entity.ToTable("ATopping");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ToppingName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ToppingPrice).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
