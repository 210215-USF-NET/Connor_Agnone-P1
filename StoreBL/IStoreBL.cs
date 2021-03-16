using StoreModels;
using System.Collections.Generic;
namespace StoreBL
{
    public interface IStoreBL
    {
        Customer CreateCustomer(Customer newCustomer);
        Location CreateLocation(Location newLocation);
        Product CreateProduct(Product newProduct);
        List<Customer> GetCustomers();
        Customer SearchCustomerName(string customer);
        Customer GetCustomerByEmail(string  email);
        //Customer CurrentCustomer(Customer newCustomer);
        //Location CurrentLocation(Location newLocation);
        Customer DeleteCustomer(Customer customer2BDeleted);
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Inventory> GetInventory();
        List<Inventory> GetInventories(int locationID);
        Inventory GetInventory(int inventoryID);
        Location SetLocation(int locationID);
        Order CreateOrder(Order newOrder);
        Order UpdateInventory(Order newOrder);
        Inventory UpdateInventory(Inventory newInventory);
        Customer UpdateCustomer(Customer customer2BUpdated);
        /*void CreateProduct(Product newProduct);//manager functionality
        //search customer, view location inventory, place order
        Customer SearchCustomer();
        void PlaceOrder();*/
    }
}