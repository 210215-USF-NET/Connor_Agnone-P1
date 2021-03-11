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
            throw new NotImplementedException();
        }

        public Order CreateOrder(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public Product CreateProduct(Product newProduct)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers
                .AsNoTracking()
                .Select(customer => customer)
                .ToList();
        }

        public List<Inventory> GetInventories()
        {
            throw new NotImplementedException();
        }

        public List<Location> GetLocations()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public Customer SearchCustomerName(string name)
        {
            return _context.Customers
                .AsNoTracking()
                .FirstOrDefault(customer => customer.CustomerName == name);
        }

        public Location SetLocation(int locationID)
        {
            throw new NotImplementedException();
        }

        public Order UpdateInventory(Order newOrder)
        {
            throw new NotImplementedException();
        }
    }
}