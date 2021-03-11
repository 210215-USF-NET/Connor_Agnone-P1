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
        //Customer CurrentCustomer(Customer newCustomer);
        //Location CurrentLocation(Location newLocation);
        Customer DeleteCustomer(Customer customer2BDeleted);
        List<Location> GetLocations();
        List<Product> GetProducts();
        List<Inventory> GetInventories();
        Order CreateOrder(Order newOrder);
        Order UpdateInventory(Order newOrder);
        /*void CreateProduct(Product newProduct);//manager functionality
        //search customer, view location inventory, place order
        Customer SearchCustomer();
        void PlaceOrder();*/
    }
}