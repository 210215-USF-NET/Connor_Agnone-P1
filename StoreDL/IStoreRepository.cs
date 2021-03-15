using StoreModels;
using System.Collections.Generic;
namespace StoreDL
{
    public interface IStoreRepository
    {
        Customer CreateCustomer(Customer newCustomer);
        Location CreateLocation(Location newLocation);
        Product CreateProduct(Product newProduct);
        List<Customer> GetCustomers();
        Customer SearchCustomerName(string name);
        Location SetLocation(int locationID);
        Customer DeleteCustomer(Customer customer2BDeleted);
        List<Location> GetLocations();
        List<Inventory> GetInventories(int locationID);
        List<Inventory> GetInventory();
        Inventory GetInventory(int inventoryID);
        List<Product> GetProducts();
        Location CurrentLocation(Location newLocation);
        Customer CurrentCustomer(Customer newCustomer);
        Order CreateOrder(Order newOrder);
        Order UpdateInventory(Order newOrder);
        Inventory UpdateInventory(Inventory inventory2BUpdated);
        Customer UpdateCustomer(Customer customer2BUpdated);
    }
}