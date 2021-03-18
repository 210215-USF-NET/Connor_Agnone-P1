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
            
            
            //Seed data
            modelBuilder.Entity<Location>()
                .HasData(
                    new Location{
                        Id = 1,
                        LocationName = "Cauldrons, Caustics, and candles",
                        LocationAddress = "555 Broomstick Dr"
                    },
                    new Location{
                        Id = 2,
                        LocationName = "Cauldron of Curiosities",
                        LocationAddress = "42 Universe Ave"
                    },
                    new Location{
                        Id = 3,
                        LocationName = "Which Craft for the Soul",
                        LocationAddress = "76 Bakers Rd"
                    }
                );
            modelBuilder.Entity<Product>()
                .HasData(
                    new Product{
                        Id = 1,
                        ProductName = "Bainberry",
                        ProductPrice = 15M
                    },
                    new Product{
                        Id = 2,
                        ProductName = "Bat Drool",
                        ProductPrice = 5.50M
                    },
                    new Product{
                        Id = 3,
                        ProductName = "Bat Wool",
                        ProductPrice = 7
                    },
                    new Product{
                        Id = 4,
                        ProductName = "Blueleaf",
                        ProductPrice = 3
                    },
                    new Product{
                        Id = 5,
                        ProductName = "Cobweb",
                        ProductPrice = 1.50M
                    },
                    new Product{
                        Id = 6,
                        ProductName = "Crystal",
                        ProductPrice = 5
                    },
                    new Product{
                        Id = 7,
                        ProductName = "Dragonwort",
                        ProductPrice = 12
                    },
                    new Product{
                        Id = 8,
                        ProductName = "Feather of Crow",
                        ProductPrice = 8
                    },
                    new Product{
                        Id = 9,
                        ProductName = "Foxglove",
                        ProductPrice = 6
                    },
                    new Product{
                        Id = 10,
                        ProductName = "Eye of Newt",
                        ProductPrice = 12
                    },
                    new Product{
                        Id = 11,
                        ProductName = "Frog Tongue",
                        ProductPrice = 15
                    },
                    new Product{
                        Id = 12,
                        ProductName = "Mandrake",
                        ProductPrice = 12
                    }
                );
                modelBuilder.Entity<Inventory>()
                    .HasData(
                        new Inventory{
                            Id = 1,
                            ProductID = 1,
                            LocationID = 1,
                            InventoryQuantity = 6
                        },
                        new Inventory{
                            Id = 2,
                            ProductID = 2,
                            LocationID = 1,
                            InventoryQuantity = 25
                        },
                        new Inventory{
                            Id = 3,
                            ProductID = 3,
                            LocationID = 1,
                            InventoryQuantity = 10
                        },
                        new Inventory{
                            Id = 4,
                            ProductID = 4,
                            LocationID = 1,
                            InventoryQuantity = 50
                        },
                        new Inventory{
                            Id = 5,
                            ProductID = 5,
                            LocationID = 1,
                            InventoryQuantity = 20
                        },
                        new Inventory{
                            Id = 6,
                            ProductID = 6,
                            LocationID = 1,
                            InventoryQuantity = 10
                        },
                        new Inventory{
                            Id = 7,
                            ProductID = 7,
                            LocationID = 1,
                            InventoryQuantity = 5
                        },
                        new Inventory{
                            Id = 8,
                            ProductID = 8,
                            LocationID = 1,
                            InventoryQuantity = 30
                        },
                        new Inventory{
                            Id = 9,
                            ProductID = 9,
                            LocationID = 1,
                            InventoryQuantity = 22
                        },
                        new Inventory{
                            Id = 10,
                            ProductID = 10,
                            LocationID = 1,
                            InventoryQuantity = 10
                        },
                        new Inventory{
                            Id = 11,
                            ProductID = 11,
                            LocationID = 1,
                            InventoryQuantity = 2
                        },
                        new Inventory{
                            Id = 12,
                            ProductID = 12,
                            LocationID = 1,
                            InventoryQuantity = 3
                        },
                        new Inventory{
                            Id = 13,
                            ProductID = 1,
                            LocationID = 2,
                            InventoryQuantity = 12
                        },
                        new Inventory{
                            Id = 14,
                            ProductID = 2,
                            LocationID = 2,
                            InventoryQuantity = 13
                        },
                        new Inventory{
                            Id = 15,
                            ProductID = 3,
                            LocationID = 2,
                            InventoryQuantity = 8
                        },
                        new Inventory{
                            Id = 16,
                            ProductID = 4,
                            LocationID = 2,
                            InventoryQuantity = 30
                        },
                        new Inventory{
                            Id = 17,
                            ProductID = 5,
                            LocationID = 2,
                            InventoryQuantity = 13
                        },
                        new Inventory{
                            Id = 18,
                            ProductID = 6,
                            LocationID = 2,
                            InventoryQuantity = 4
                        },
                        new Inventory{
                            Id = 19,
                            ProductID = 7,
                            LocationID = 2,
                            InventoryQuantity = 10
                        },
                        new Inventory{
                            Id = 20,
                            ProductID = 8,
                            LocationID = 2,
                            InventoryQuantity = 3
                        },
                        new Inventory{
                            Id = 21,
                            ProductID = 9,
                            LocationID = 2,
                            InventoryQuantity = 4
                        },
                        new Inventory{
                            Id = 22,
                            ProductID = 10,
                            LocationID = 2,
                            InventoryQuantity = 2
                        },
                        new Inventory{
                            Id = 23,
                            ProductID = 11,
                            LocationID = 2,
                            InventoryQuantity = 5
                        },
                        new Inventory{
                            Id = 24,
                            ProductID = 12,
                            LocationID = 2,
                            InventoryQuantity = 14
                        },
                        new Inventory{
                            Id = 25,
                            ProductID = 1,
                            LocationID = 3,
                            InventoryQuantity = 5
                        },
                        new Inventory{
                            Id = 26,
                            ProductID = 2,
                            LocationID = 3,
                            InventoryQuantity = 25
                        },
                        new Inventory{
                            Id = 27,
                            ProductID = 3,
                            LocationID = 3,
                            InventoryQuantity = 20
                        },
                        new Inventory{
                            Id = 28,
                            ProductID = 4,
                            LocationID = 3,
                            InventoryQuantity = 10
                        },
                        new Inventory{
                            Id = 29,
                            ProductID = 5,
                            LocationID = 3,
                            InventoryQuantity = 6
                        },
                        new Inventory{
                            Id = 30,
                            ProductID = 6,
                            LocationID = 3,
                            InventoryQuantity = 2
                        },
                        new Inventory{
                            Id = 31,
                            ProductID = 7,
                            LocationID = 3,
                            InventoryQuantity = 15
                        },
                        new Inventory{
                            Id = 32,
                            ProductID = 8,
                            LocationID = 3,
                            InventoryQuantity = 5
                        },
                        new Inventory{
                            Id = 33,
                            ProductID = 9,
                            LocationID = 3,
                            InventoryQuantity = 20
                        },
                        new Inventory{
                            Id = 34,
                            ProductID = 10,
                            LocationID = 3,
                            InventoryQuantity = 8
                        },
                        new Inventory{
                            Id = 35,
                            ProductID = 11,
                            LocationID = 3,
                            InventoryQuantity = 8
                        },
                        new Inventory{
                            Id = 36,
                            ProductID = 12,
                            LocationID = 3,
                            InventoryQuantity = 7
                        }
                    );
        }

    }
}