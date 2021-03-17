using System.Collections.Generic;
using StoreModels;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StoreDL
{
    public class StoreRepoDB : IStoreRepository
    {
        private readonly StoreDBContext _context;
        public StoreRepoDB(StoreDBContext context)
        {
            _context = context;
        }
        public Customer CreateCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }
        //gonna be seeding locations, products, and inventories so these implementations shouldn't need implemented.
        public Location CreateLocation(Location newLocation)
        {
            _context.Locations.Add(newLocation);
            _context.SaveChanges();
            return newLocation;
        }

        public Order CreateOrder(Order newOrder)
        {
            Order finalOrder = new Order();
            finalOrder.CustomerID = newOrder.CustomerID;
            finalOrder.LocationID = newOrder.LocationID;
            finalOrder.OrderDate = newOrder.OrderDate;
            finalOrder.OrderTotal = newOrder.OrderTotal;
            finalOrder.OrderItems = new List<OrderItems>();
            OrderItems temp = new OrderItems();
            foreach (var item in newOrder.OrderItems)
            {
                temp.ProductID = item.ProductID;
                temp.OrderQuantity = item.OrderQuantity;
                finalOrder.OrderItems.Add(temp);
            }
            _context.Orders.Add(finalOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public Product CreateProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public Customer CurrentCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public Location CurrentLocation(Location newLocation)
        {
            throw new NotImplementedException();
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            _context.Customers.Remove(customer2BDeleted);
            _context.SaveChanges();
            return customer2BDeleted;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(customer => customer.CustomerEmail == email);
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers
                .AsNoTracking()
                .Select(customer => customer)
                .ToList();
        }

        public List<Inventory> GetInventories(int locationID)
        {
            List<Product> products = _context.Products
                                            .AsNoTracking()
                                            .Select(product => product)
                                            .ToList();
            List<Inventory> inventory = _context.Inventories
                                            .AsNoTracking()
                                            .Where(inventory => inventory.LocationID == locationID)
                                            .ToList();
            for(int i = 0; i < inventory.Count; i++)
            {
                foreach(var product in products)
                {
                    if(product.Id == inventory[i].ProductID)
                    {
                        inventory[i].InventoryProduct = product;
                        break;
                    }
                }
            }
            
            return inventory;
        }
        public Inventory GetInventory(int inventoryID)
        {
            Inventory inventory = _context.Inventories
                                            .AsNoTracking()
                                            .Where(inventory => inventory.Id == inventoryID)
                                            .FirstOrDefault();
            List<Product> products = _context.Products
                                            .AsNoTracking()
                                            .Select(product => product)
                                            .ToList();
            
            foreach(var product in products)
            {
                if(product.Id == inventory.ProductID)
                {
                    inventory.InventoryProduct = product;
                    break;
                }
            }
            return inventory;
        }

        public List<Inventory> GetInventory()
        {
            return _context.Inventories
                .AsNoTracking()
                .Select(inventory => inventory)
                .ToList();
        }

        public List<Location> GetLocations()
        {
            return _context.Locations
                .AsNoTracking()
                .Select(location => location)
                .ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products
                .AsNoTracking()
                .Select(product => product)
                .ToList();
        }

        public Customer SearchCustomerName(string name)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(customer => customer.CustomerName == name);
        }

        public Location SetLocation(int locationID)
        {
            return _context.Locations
                .AsNoTracking()
                .FirstOrDefault(location => location.Id == locationID);
        }

        public Customer UpdateCustomer(Customer customer2BUpdated)
        {
            Customer oldCustomer = _context.Customers.Find(customer2BUpdated.Id);
            _context.Entry(oldCustomer).CurrentValues.SetValues(customer2BUpdated);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return customer2BUpdated;
        }

        public Order UpdateInventory(Order newOrder)
        {
            
            List<Product> products = _context.Products
                                            .AsNoTracking()
                                            .Select(product => product)
                                            .ToList();
            List<Inventory> currentInventory = _context.Inventories
                                            .AsNoTracking()
                                            .Where(inventory => inventory.LocationID == newOrder.LocationID)
                                            .ToList();
            for(int i = 0; i < currentInventory.Count; i++)
            {
                foreach(var product in products)
                {
                    if(product.Id == currentInventory[i].ProductID)
                    {
                        currentInventory[i].InventoryProduct = product;
                        break;
                    }
                }
            }
            foreach (var item in newOrder.OrderItems)
            {
                foreach (var inventory in currentInventory)
                {
                    if(item.OrderItemProduct.Id == inventory.InventoryProduct.Id)
                    {
                        Inventory temp  = inventory;
                        temp.InventoryQuantity = temp.InventoryQuantity - item.OrderQuantity;
                        Inventory oldInventory = _context.Inventories.Find(inventory.Id);
                        _context.Entry(oldInventory).CurrentValues.SetValues(temp);
                        temp = UpdateInventory(temp);
                    }
                }
            }
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return newOrder;
        }

        public Inventory UpdateInventory(Inventory inventory2BUpdated)
        {
            Inventory oldInventory = _context.Inventories.Find(inventory2BUpdated.Id);
            _context.Entry(oldInventory).CurrentValues.SetValues(inventory2BUpdated);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return inventory2BUpdated;
        }
    }
}