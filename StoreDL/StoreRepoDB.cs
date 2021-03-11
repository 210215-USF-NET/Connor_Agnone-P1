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
            _context.Customers.Remove(customer2BDeleted);
            _context.SaveChanges();
            return customer2BDeleted;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}