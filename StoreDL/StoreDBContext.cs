using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StoreModels;
namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions options) : base(options)
        {
        }
        protected StoreDBContext()
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>()
                .Property(location => location.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .Property(product => product.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>()
                .Property(inventory => inventory.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
                .Property(order => order.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<OrderItems>()
                .Property(orderItem => orderItem.Id)
                .ValueGeneratedOnAdd();
            
        }

    }
}