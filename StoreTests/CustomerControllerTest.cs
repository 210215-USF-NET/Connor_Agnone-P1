using Xunit;
using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Moq;
using StoreBL;
using StoreDL;
using StoreModels;
using MvcStore;
using MvcStore.Controllers;
using MvcStore.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
namespace StoreTests
{
    public class CustomerControllerTest
    {
        [Fact]
        public void CustomerControllerShouldReturnIndex()
        {
            var mockRepo = new Mock<IStoreBL>();
            mockRepo.Setup(x => x.GetCustomers())
                .Returns(new List<Customer>()
                {
                    new Customer
                    {
                        Id = 1,
                        CustomerName = "Joe",
                        CustomerEmail = "joeschmoe@fake.email"
                    },
                    new Customer
                    {
                        Id = 2,
                        CustomerName = "Jack",
                        CustomerEmail = "jack@email.com"
                    }
                });
            var logger = new NullLogger<CustomerController>();
            var controller = new CustomerController(mockRepo.Object, new Mapper(), logger);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerIndexVM>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public void LocationControllerShouldReturnIndex()
        {
            var mockRepo = new Mock<IStoreBL>();
            mockRepo.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
                    new Location
                    {
                        Id = 1,
                        LocationName = "Joe",
                        LocationAddress = "joeschmoe@fake.email"
                    },
                    new Location
                    {
                        Id = 2,
                        LocationName = "Jack",
                        LocationAddress = "jack@email.com"
                    }
                });
            var logger = new NullLogger<LocationController>();
            var controller = new LocationController(mockRepo.Object, new Mapper(), logger);

            var result = controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<LocationIndexVM>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public void Test()
        {
            Customer customer = new Customer();
            customer.Id = 3;
            Assert.Equal(3,customer.Id);
        }

        private readonly DbContextOptions<StoreDBContext> options;
        public CustomerControllerTest()
        {
            options = new DbContextOptionsBuilder<StoreDBContext>()
                        .UseSqlite("Filename=Test.db")
                        .Options;
            Seed();
        }
        [Fact]
        public void GetLocationsShouldReturnAllLocations()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var locations = _repo.GetLocations();
                Assert.Equal(5, locations.Count);
            }
        }
        [Fact]
        public void GetCustomersShouldReturnAllCustomers()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var customers = _repo.GetCustomers();
                Assert.Equal(2, customers.Count);
            }
        }
        [Fact]
        public void GetProductsShouldGetAllProducts()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var products = _repo.GetProducts();
                Assert.Equal(15, products.Count);
            }
        }
        [Fact]
        public void GetInventoriesShouldGetAllInventories()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var inventories = _repo.GetInventory();
                Assert.Equal(42, inventories.Count);
            }
        }
        [Fact]
        public void SearchCustomerNameShouldReturnCustomer()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var foundCustomer = _repo.SearchCustomerName("Joe");

                Assert.NotNull(foundCustomer);
                Assert.Equal("Joe", foundCustomer.CustomerName);
            }
        }
        [Fact]
        public void SetLocationShouldReturnLocation()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var foundLocation = _repo.SetLocation(2);

                Assert.NotNull(foundLocation);
                Assert.Equal(2, foundLocation.Id);
            }
        }
        [Fact]
        public void CreateCustomerShouldCreateCustomer()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                _repo.CreateCustomer
                (
                    new Customer
                    {
                        CustomerName = "Zach",
                        CustomerEmail = "zach@email.com"
                    }
                );
            }
            using(var assertContext = new StoreDBContext(options))
            {
                var result = assertContext.Customers.FirstOrDefault(customer => customer.CustomerName == "Zach");
                Assert.NotNull(result);
                Assert.Equal("Zach", result.CustomerName);
            }
        }
        [Fact]
        public void DeleteCustomerShouldDeleteCustomer()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                _repo.DeleteCustomer
                (
                    new Customer
                    {
                        Id = 1,
                        CustomerName = "Joe",
                        CustomerEmail = "joe@email.com"
                    }
                );
            }
            using(var assertContext = new StoreDBContext(options))
            {
                var result = assertContext.Customers.FirstOrDefault(customer => customer.CustomerName == "Joe");
                Assert.Null(result);
            }
        }
        [Fact]
        public void GetInventoryGivenLocationIDShouldReturnInventoriesAtLocation()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                List<Inventory> inventories = new List<Inventory>();
                inventories.Add(_repo.GetInventory(2));
                Assert.Equal(1, inventories.Count);
            }
        }
        [Fact]
        public void GetCustomerEmailShouldReturnCustomer()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                var foundCustomer = _repo.GetCustomerByEmail("joe@email.com");

                Assert.NotNull(foundCustomer);
                Assert.Equal("joe@email.com", foundCustomer.CustomerEmail);
            }
        }
        [Fact]
        public void CreateProductShouldCreateProduct()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                _repo.CreateProduct
                (
                    new Product
                    {
                        ProductName = "Bat Tears",
                        ProductPrice = 5
                    }
                );
            }
            using(var assertContext = new StoreDBContext(options))
            {
                var result = assertContext.Products.FirstOrDefault(product => product.ProductName == "Bat Tears");
                Assert.NotNull(result);
                Assert.Equal("Bat Tears", result.ProductName);
            }
        }
        [Fact]
        public void CreateLocationShouldCreateLocation()
        {
            using(var context = new StoreDBContext(options))
            {
                IStoreRepository _repo = new StoreRepoDB(context);
                _repo.CreateLocation
                (
                    new Location
                    {
                        LocationName = "Mandrakes R US",
                        LocationAddress = "69 Floral Dr."
                    }
                );
            }
            using(var assertContext = new StoreDBContext(options))
            {
                var result = assertContext.Locations.FirstOrDefault(location => location.LocationName == "Mandrakes R US");
                Assert.NotNull(result);
                Assert.Equal("Mandrakes R US", result.LocationName);
            }
        }

        private void Seed()
        {
            using(var context = new StoreDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange
                (
                    new Customer
                    {
                        CustomerName = "Joe",
                        CustomerEmail = "joe@email.com"
                    },
                    new Customer
                    {
                        CustomerName = "Sally",
                        CustomerEmail = "sallyride@email.com"
                    }
                );
                context.Locations.AddRange
                (
                    new Location
                    {
                        LocationName = "Bats and Brews",
                        LocationAddress = "55 Bat Dr."
                    },
                    new Location
                    {
                        LocationName = "Goblin's and Ghouls",
                        LocationAddress = "42 Universe St"
                    }
                );
                context.Products.AddRange
                (
                    new Product
                    {
                        ProductName = "Eye of Newt",
                        ProductPrice = 1
                    },
                    new Product
                    {
                        ProductName = "Bat Wool",
                        ProductPrice = 3
                    },
                    new Product
                    {
                        ProductName = "Mandrake",
                        ProductPrice = 12
                    }
                );
                context.Inventories.AddRange
                (
                    new Inventory
                    {
                        ProductID = 1,
                        LocationID = 1,
                        InventoryQuantity = 12
                    },
                    new Inventory
                    {
                        ProductID = 2,
                        LocationID = 1,
                        InventoryQuantity = 9
                    },
                    new Inventory
                    {
                        ProductID = 3,
                        LocationID = 1,
                        InventoryQuantity = 3
                    },
                    new Inventory
                    {
                        ProductID = 1,
                        LocationID = 2,
                        InventoryQuantity = 5
                    },
                    new Inventory
                    {
                        ProductID = 2,
                        LocationID = 2,
                        InventoryQuantity = 10
                    },
                    new Inventory
                    {
                        ProductID = 3,
                        LocationID = 2,
                        InventoryQuantity = 5
                    }
                );
                context.SaveChanges();
            }
        }
    }
}