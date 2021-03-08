using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public class StoreRepoSC : IStoreRepository
    {
        public List<Customer> GetCustomers()
        {
            return Storage.AllCustomers;
        }
        public Customer CreateCustomer(Customer newCustomer)
        {
            Storage.AllCustomers.Add(newCustomer);
            return newCustomer;
        }
        public Location CreateLocation(Location newLocation)
        {
            Storage.AllLocations.Add(newLocation);
            return newLocation;
        }
        public Product CreateProduct(Product newProduct)
        {
            Storage.AllProducts.Add(newProduct);
            return newProduct;
        }

        public Customer SearchCustomerName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            throw new System.NotImplementedException();
        }

        public List<Location> GetLocations(Location location)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public Location SetLocation(int locationID)
        {
            throw new System.NotImplementedException();
        }

        public List<Inventory> GetInventories()
        {
            throw new System.NotImplementedException();
        }

        public List<Location> GetLocations()
        {
            throw new System.NotImplementedException();
        }

        public List<Inventory> GetInventories(Location location)
        {
            throw new System.NotImplementedException();
        }

        public Location CurrentLocation(Location newLocation)
        {
            throw new System.NotImplementedException();
        }

        public Customer CurrentCustomer(Customer newCustomer)
        {
            throw new System.NotImplementedException();
        }

        public Order CreateOrder(Order newOrder)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateInventory(Order newOrder)
        {
            throw new System.NotImplementedException();
        }
    }
}