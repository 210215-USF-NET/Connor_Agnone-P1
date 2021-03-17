﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StoreDL;

namespace StoreDL.Migrations
{
    [DbContext(typeof(StoreDBContext))]
    [Migration("20210317155959_OrderITemFix")]
    partial class OrderITemFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("StoreModels.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("text");

                    b.Property<string>("CustomerName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("StoreModels.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("InventoryQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("LocationID");

                    b.HasIndex("ProductID");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            InventoryQuantity = 6,
                            LocationID = 1,
                            ProductID = 1
                        },
                        new
                        {
                            Id = 2,
                            InventoryQuantity = 25,
                            LocationID = 1,
                            ProductID = 2
                        },
                        new
                        {
                            Id = 3,
                            InventoryQuantity = 10,
                            LocationID = 1,
                            ProductID = 3
                        },
                        new
                        {
                            Id = 4,
                            InventoryQuantity = 50,
                            LocationID = 1,
                            ProductID = 4
                        },
                        new
                        {
                            Id = 5,
                            InventoryQuantity = 20,
                            LocationID = 1,
                            ProductID = 5
                        },
                        new
                        {
                            Id = 6,
                            InventoryQuantity = 10,
                            LocationID = 1,
                            ProductID = 6
                        },
                        new
                        {
                            Id = 7,
                            InventoryQuantity = 5,
                            LocationID = 1,
                            ProductID = 7
                        },
                        new
                        {
                            Id = 8,
                            InventoryQuantity = 30,
                            LocationID = 1,
                            ProductID = 8
                        },
                        new
                        {
                            Id = 9,
                            InventoryQuantity = 22,
                            LocationID = 1,
                            ProductID = 9
                        },
                        new
                        {
                            Id = 10,
                            InventoryQuantity = 10,
                            LocationID = 1,
                            ProductID = 10
                        },
                        new
                        {
                            Id = 11,
                            InventoryQuantity = 2,
                            LocationID = 1,
                            ProductID = 11
                        },
                        new
                        {
                            Id = 12,
                            InventoryQuantity = 3,
                            LocationID = 1,
                            ProductID = 12
                        },
                        new
                        {
                            Id = 13,
                            InventoryQuantity = 12,
                            LocationID = 2,
                            ProductID = 1
                        },
                        new
                        {
                            Id = 14,
                            InventoryQuantity = 13,
                            LocationID = 2,
                            ProductID = 2
                        },
                        new
                        {
                            Id = 15,
                            InventoryQuantity = 8,
                            LocationID = 2,
                            ProductID = 3
                        },
                        new
                        {
                            Id = 16,
                            InventoryQuantity = 30,
                            LocationID = 2,
                            ProductID = 4
                        },
                        new
                        {
                            Id = 17,
                            InventoryQuantity = 13,
                            LocationID = 2,
                            ProductID = 5
                        },
                        new
                        {
                            Id = 18,
                            InventoryQuantity = 4,
                            LocationID = 2,
                            ProductID = 6
                        },
                        new
                        {
                            Id = 19,
                            InventoryQuantity = 10,
                            LocationID = 2,
                            ProductID = 7
                        },
                        new
                        {
                            Id = 20,
                            InventoryQuantity = 3,
                            LocationID = 2,
                            ProductID = 8
                        },
                        new
                        {
                            Id = 21,
                            InventoryQuantity = 4,
                            LocationID = 2,
                            ProductID = 9
                        },
                        new
                        {
                            Id = 22,
                            InventoryQuantity = 2,
                            LocationID = 2,
                            ProductID = 10
                        },
                        new
                        {
                            Id = 23,
                            InventoryQuantity = 5,
                            LocationID = 2,
                            ProductID = 11
                        },
                        new
                        {
                            Id = 24,
                            InventoryQuantity = 14,
                            LocationID = 2,
                            ProductID = 12
                        },
                        new
                        {
                            Id = 25,
                            InventoryQuantity = 5,
                            LocationID = 3,
                            ProductID = 1
                        },
                        new
                        {
                            Id = 26,
                            InventoryQuantity = 25,
                            LocationID = 3,
                            ProductID = 2
                        },
                        new
                        {
                            Id = 27,
                            InventoryQuantity = 20,
                            LocationID = 3,
                            ProductID = 3
                        },
                        new
                        {
                            Id = 28,
                            InventoryQuantity = 10,
                            LocationID = 3,
                            ProductID = 4
                        },
                        new
                        {
                            Id = 29,
                            InventoryQuantity = 6,
                            LocationID = 3,
                            ProductID = 5
                        },
                        new
                        {
                            Id = 30,
                            InventoryQuantity = 2,
                            LocationID = 3,
                            ProductID = 6
                        },
                        new
                        {
                            Id = 31,
                            InventoryQuantity = 15,
                            LocationID = 3,
                            ProductID = 7
                        },
                        new
                        {
                            Id = 32,
                            InventoryQuantity = 5,
                            LocationID = 3,
                            ProductID = 8
                        },
                        new
                        {
                            Id = 33,
                            InventoryQuantity = 20,
                            LocationID = 3,
                            ProductID = 9
                        },
                        new
                        {
                            Id = 34,
                            InventoryQuantity = 8,
                            LocationID = 3,
                            ProductID = 10
                        },
                        new
                        {
                            Id = 35,
                            InventoryQuantity = 8,
                            LocationID = 3,
                            ProductID = 11
                        },
                        new
                        {
                            Id = 36,
                            InventoryQuantity = 7,
                            LocationID = 3,
                            ProductID = 12
                        });
                });

            modelBuilder.Entity("StoreModels.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("LocationAddress")
                        .HasColumnType("text");

                    b.Property<string>("LocationName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LocationAddress = "555 Broomstick Dr",
                            LocationName = "Cauldrons, Caustics, and candles"
                        },
                        new
                        {
                            Id = 2,
                            LocationAddress = "42 Universe Ave",
                            LocationName = "Cauldron of Curiosities"
                        },
                        new
                        {
                            Id = 3,
                            LocationAddress = "76 Bakers Rd",
                            LocationName = "Which Craft for the Soul"
                        });
                });

            modelBuilder.Entity("StoreModels.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerID")
                        .HasColumnType("integer");

                    b.Property<int>("LocationID")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("OrderTotal")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("StoreModels.OrderItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderID")
                        .HasColumnType("integer");

                    b.Property<int>("OrderQuantity")
                        .HasColumnType("integer");

                    b.Property<int>("ProductID")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID")
                        .IsUnique();

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("StoreModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ProductName")
                        .HasColumnType("text");

                    b.Property<decimal>("ProductPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductName = "Bainberry",
                            ProductPrice = 15m
                        },
                        new
                        {
                            Id = 2,
                            ProductName = "Bat Drool",
                            ProductPrice = 5.50m
                        },
                        new
                        {
                            Id = 3,
                            ProductName = "Bat Wool",
                            ProductPrice = 7m
                        },
                        new
                        {
                            Id = 4,
                            ProductName = "Blueleaf",
                            ProductPrice = 3m
                        },
                        new
                        {
                            Id = 5,
                            ProductName = "Cobweb",
                            ProductPrice = 1.50m
                        },
                        new
                        {
                            Id = 6,
                            ProductName = "Crystal",
                            ProductPrice = 5m
                        },
                        new
                        {
                            Id = 7,
                            ProductName = "Dragonwort",
                            ProductPrice = 12m
                        },
                        new
                        {
                            Id = 8,
                            ProductName = "Feather of Crow",
                            ProductPrice = 8m
                        },
                        new
                        {
                            Id = 9,
                            ProductName = "Foxglove",
                            ProductPrice = 6m
                        },
                        new
                        {
                            Id = 10,
                            ProductName = "Eye of Newt",
                            ProductPrice = 12m
                        },
                        new
                        {
                            Id = 11,
                            ProductName = "Frog Tongue",
                            ProductPrice = 15m
                        },
                        new
                        {
                            Id = 12,
                            ProductName = "Mandrake",
                            ProductPrice = 12m
                        });
                });

            modelBuilder.Entity("StoreModels.Inventory", b =>
                {
                    b.HasOne("StoreModels.Location", null)
                        .WithMany("Inventory")
                        .HasForeignKey("LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreModels.Product", "InventoryProduct")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("InventoryProduct");
                });

            modelBuilder.Entity("StoreModels.Order", b =>
                {
                    b.HasOne("StoreModels.Customer", null)
                        .WithOne("CustomerOrder")
                        .HasForeignKey("StoreModels.Order", "CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StoreModels.OrderItems", b =>
                {
                    b.HasOne("StoreModels.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StoreModels.Product", "OrderItemProduct")
                        .WithOne()
                        .HasForeignKey("StoreModels.OrderItems", "ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderItemProduct");
                });

            modelBuilder.Entity("StoreModels.Customer", b =>
                {
                    b.Navigation("CustomerOrder");
                });

            modelBuilder.Entity("StoreModels.Location", b =>
                {
                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("StoreModels.Order", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
