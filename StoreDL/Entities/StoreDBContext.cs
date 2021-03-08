using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace StoreDL.Entities
{
    public partial class StoreDBContext : DbContext
    {
        public StoreDBContext()
        {
        }

        public StoreDBContext(DbContextOptions<StoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.ToTable("inventory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InventoryLocation).HasColumnName("inventoryLocation");

                entity.Property(e => e.InventoryProduct).HasColumnName("inventoryProduct");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.InventoryLocationNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InventoryLocation)
                    .HasConstraintName("FK__inventory__inven__42E1EEFE");

                entity.HasOne(d => d.InventoryProductNavigation)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.InventoryProduct)
                    .HasConstraintName("FK__inventory__inven__41EDCAC5");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LocationAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderCustomer).HasColumnName("orderCustomer");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.OrderLocation).HasColumnName("orderLocation");

                entity.HasOne(d => d.OrderCustomerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderCustomer)
                    .HasConstraintName("FK__orders__orderCus__3E1D39E1");

                entity.HasOne(d => d.OrderLocationNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderLocation)
                    .HasConstraintName("FK__orders__orderLoc__3F115E1A");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.ToTable("orderItems");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderProduct).HasColumnName("orderProduct");

                entity.Property(e => e.OrderQuantity).HasColumnName("orderQuantity");

                entity.Property(e => e.OrdersId).HasColumnName("ordersID");

                entity.HasOne(d => d.OrderProductNavigation)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrderProduct)
                    .HasConstraintName("FK__orderItem__order__46B27FE2");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.OrdersId)
                    .HasConstraintName("FK__orderItem__order__45BE5BA9");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProductPrice).HasColumnType("decimal(5, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
