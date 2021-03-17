using StoreModels;

namespace MvcStore.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2BCasted)
        {
            return new CustomerIndexVM
            {
                CustomerName = customer2BCasted.CustomerName,
                CustomerEmail = customer2BCasted.CustomerEmail
            };
        }
        public Customer cast2Customer(CustomerCRVM customer2bCasted)
        {
            return new Customer
            {
                CustomerName = customer2bCasted.CustomerName,
                CustomerEmail = customer2bCasted.CustomerEmail
            };
        }
        public CustomerCRVM cast2CustomerCRVM(Customer customer)
        {
            return new CustomerCRVM
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail
            };
        }
        public Customer cast2Customer(CustomerEditVM customer2BCasted)
        {
            return new Customer
            {
                Id = customer2BCasted.CustomerId,
                CustomerName = customer2BCasted.CustomerName,
                CustomerEmail = customer2BCasted.CustomerEmail
            };
        }
        public CustomerEditVM cast2CustomerEditVM(Customer customer)
        {
            return new CustomerEditVM
            {
                CustomerId = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail
            };
        }
        public LocationIndexVM cast2LocationIndexVM(Location location2BCasted)
        {
            return new LocationIndexVM
            {
                LocationName = location2BCasted.LocationName,
                LocationAddress = location2BCasted.LocationAddress,
                LocationID = location2BCasted.Id
            };
        }
        public Inventory cast2Inventory(LocationIVM inventory2BCasted)
        {
            return new Inventory
            {
                InventoryQuantity = inventory2BCasted.InventroyQuantity,
                LocationID = inventory2BCasted.LocationId,
                Id = inventory2BCasted.InventoryId,
                InventoryProduct = new Product
                {
                    ProductName = inventory2BCasted.ProductName,
                    ProductPrice = inventory2BCasted.ProductPrice
                }
            };
        }

        public LocationIVM cast2LocationIVM(Inventory inventory2BCasted)
        {
            return new LocationIVM
            {
                ProductName = inventory2BCasted.InventoryProduct.ProductName,
                ProductPrice = inventory2BCasted.InventoryProduct.ProductPrice,
                InventroyQuantity = inventory2BCasted.InventoryQuantity,
                LocationId = inventory2BCasted.LocationID,
                InventoryId = inventory2BCasted.Id
            };
        }

        public Inventory cast2Inventory(LocationEditVM inventory2BCasted)
        {
            return new Inventory
            {
                InventoryQuantity = inventory2BCasted.InventoryQuantity,
                LocationID = inventory2BCasted.LocationId,
                Id = inventory2BCasted.InventoryId,
                ProductID = inventory2BCasted.ProductId,
            };
        }

        public LocationEditVM cast2LocationEditVM(Inventory inventory)
        {
            return new LocationEditVM
            {
                LocationId = inventory.LocationID,
                InventoryId = inventory.Id,
                InventoryQuantity = inventory.InventoryQuantity,
                ProductName = inventory.InventoryProduct.ProductName,
                ProductPrice = inventory.InventoryProduct.ProductPrice,
                ProductId = inventory.InventoryProduct.Id
            };
        }

        public CheckoutVM cast2CheckoutVM(OrderItems orderItems)
        {
            return new CheckoutVM
            {
                Quantity = orderItems.OrderQuantity,
                ProductName = orderItems.OrderItemProduct.ProductName,
                ProductPrice = orderItems.OrderItemProduct.ProductPrice,
                ProductID = orderItems.OrderItemProduct.Id
            };
        }
    }
}