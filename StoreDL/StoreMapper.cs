using Model = StoreModels;
using Entity = StoreDL.Entities;
using StoreModels;
using StoreDL;
using System.Collections.Generic;
using System.Linq;
using StoreDL.Entities;

namespace StoreDL
{
    public class StoreMapper : IMapper
    {
        public Model.Customer ParseCustomer(Entity.Customer customer)
        {
            return new Model.Customer
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CustomerID = customer.Id
            };
        }

        public Entity.Customer ParseCustomer(Model.Customer customer)
        {
            if(customer.CustomerID == null)
            {
                return new Entity.Customer
                {
                    CustomerName = customer.CustomerName,
                    CustomerEmail = customer.CustomerEmail
                };
            }
            return new Entity.Customer
            {
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                Id = (int)customer.CustomerID
            };
        }

        public Model.Inventory ParseInventory(Entity.Inventory inventory)
        {
            return new Model.Inventory
            {
                InventoryQuantity = inventory.Quantity,
                //InventoryProduct = ParseProduct(inventory.InventoryProductNavigation),
                InventoryID = inventory.Id,
                ProductID = inventory.InventoryProduct,
                LocationID = inventory.InventoryLocation
            };
        }
        public Entity.Inventory ParseInventory(Model.Inventory inventory)
        {
            if(inventory.InventoryID == null)
            {
                return new Entity.Inventory
                {
                    Quantity = inventory.InventoryQuantity,
                    //InventoryProductNavigation = ParseProduct(inventory.InventoryProduct),
                };
            }
            return new Entity.Inventory
            {
                Id = (int)inventory.InventoryID,
                Quantity = inventory.InventoryQuantity,
                InventoryLocation = (int) inventory.LocationID,
                InventoryProduct = (int) inventory.ProductID,
                //InventoryProductNavigation = ParseProduct(inventory.InventoryProduct)
            };
        }
        public Model.Location ParseLocation(Entity.Location location)
        {
            return new Model.Location
            {
                LocationName = location.LocationName,
                LocationAddress = location.LocationAddress,
                LocationID = location.Id,
            };
        }

        public Entity.Location ParseLocation(Model.Location location)
        {
            if(location.LocationID == null)
            {
                return new Entity.Location
                {
                    LocationName = location.LocationName,
                    LocationAddress = location.LocationAddress
                };
            }
            return new Entity.Location
            {
                LocationName = location.LocationName,
                LocationAddress = location.LocationAddress,
                Id = (int)location.LocationID
            };
        }

        public Model.Order ParseOrder(Entity.Order order)
        {
            return new Model.Order
            {
                OrderID = order.Id,
                LocationID = order.OrderLocation,
                CustomerID = order.OrderCustomer,
                //OrderDate = order.OrderDate
            };
        }

        public Entity.Order ParseOrder(Model.Order order)
        {
            if(order.OrderID == null)
            {
                return new Entity.Order()
                {
                    OrderCustomer = (int) order.CustomerID,
                    OrderLocation = (int) order.LocationID,
                    //OrderDate = order.OrderDate
                    OrderItems = order.OrderItems.Select(x => ParseOrderItems(x)).ToList()
                };
            }
            return new Entity.Order
            {
                Id = (int) order.OrderID,
                OrderCustomer = (int) order.CustomerID,
                OrderLocation = (int) order.LocationID,
                //OrderDate = order.OrderDate
            };
        }

        public Model.OrderItems ParseOrderItems(Entity.OrderItem orderItem)
        {
            return new Model.OrderItems
            {
                OrderQuantity = orderItem.OrderQuantity,
                OrderItemID = orderItem.OrderProduct,
                OrderID = orderItem.Id
            };
        }

        public Entity.OrderItem ParseOrderItems(Model.OrderItems orderItem)
        {
            /*if(orderItem.OrderID == null)
            {
                return new Entity.OrderItem
                {
                    OrderQuantity = orderItem.OrderQuantity,
                };
            }*/
            return new Entity.OrderItem
            {
                //Id = (int)orderItem.OrderID,
                //OrdersId = (int) orderItem.OrderID,
                OrderProduct = (int)orderItem.OrderItemProduct.ProductID,
                OrderQuantity = orderItem.OrderQuantity
            };
        }

        public Model.Product ParseProduct(Entity.Product product)
        {
            return new Model.Product
            {
                ProductName = product.ProductName,
                ProductPrice = (decimal)product.ProductPrice,
                ProductID = product.Id
            };
        }

        public Entity.Product ParseProduct(Model.Product product)
        {
            if(product.ProductID == null)
            {
                return new Entity.Product
                {
                    ProductName = product.ProductName,
                    ProductPrice = product.ProductPrice
                };
            }
            return new Entity.Product
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Id = (int)product.ProductID
            };
        }
    }
}