using StoreModels;
using StoreDL;
using System;
using System.Collections.Generic;
namespace StoreBL
{
    public class MyStoreBL : IStoreBL
    {
        private IStoreRepository _repo;
        public Location currentLocation{ get; set; }
        public Customer currentCustomer { get; set; }
        public MyStoreBL(IStoreRepository repo)
        {
            _repo = repo;
        }
        public Customer CreateCustomer(Customer newCustomer)
        {
            return _repo.CreateCustomer(newCustomer);
        }
        public Location CreateLocation(Location newLocation)
        {
            return _repo.CreateLocation(newLocation);
        }
        public Product CreateProduct(Product newProduct)
        {
            return _repo.CreateProduct(newProduct);
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            return _repo.DeleteCustomer(customer2BDeleted);
        }

        public List<Customer> GetCustomers()
        {
            return _repo.GetCustomers();
        }

        public List<Location> GetLocations()
        {
            return _repo.GetLocations();
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }
        public List<Inventory> GetInventories()
        {
            return _repo.GetInventories();
        }

        public Customer SearchCustomerName(string customer)
        {
            return _repo.SearchCustomerName(customer);
        }
        public Location SetLocation(int locationID)
        {
            return _repo.SetLocation(locationID);
        }

        public Order CreateOrder(Order newOrder)
        {
            return _repo.CreateOrder(newOrder);
        }

        public Order UpdateInventory(Order newOrder)
        {
            return _repo.UpdateInventory(newOrder);
        }
    }
}