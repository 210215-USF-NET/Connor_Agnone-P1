using System.Collections.Generic;
using Model = StoreModels;
using Entity = StoreDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using StoreModels;
namespace StoreDL
{
    public class StoreRepoDB : IStoreRepository
    {
        private Entity.StoreDBContext _context;
        private IMapper _mapper;
        public StoreRepoDB(Entity.StoreDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Customer CreateCustomer(Model.Customer newCustomer)
        {
            _context.Customers.Add(_mapper.ParseCustomer(newCustomer));
            _context.SaveChanges();
            return newCustomer;
        }

        public Location CreateLocation(Location newLocation)
        {
            _context.Locations.Add(_mapper.ParseLocation(newLocation));
            _context.SaveChanges();
            return newLocation;
        }

        public Order CreateOrder(Order newOrder)
        {
            _context.Orders.Add(_mapper.ParseOrder(newOrder));
            // foreach (var item in newOrder.OrderItems)
            // {
            //     //item.OrderID = newOrder.OrderID;

            //     _context.OrderItems.Add(_mapper.ParseOrderItems(item));
            // }
            _context.SaveChanges();
            return newOrder;
        }

        public Product CreateProduct(Product newProduct)
        {
            _context.Products.Add(_mapper.ParseProduct(newProduct));
            _context.SaveChanges();
            return newProduct;
        }

        public Customer CurrentCustomer(Customer newCustomer)
        {
            throw new System.NotImplementedException();
        }

        public Location CurrentLocation(Location newLocation)
        {
            throw new System.NotImplementedException();
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            _context.Customers.Remove(_mapper.ParseCustomer(customer2BDeleted));
            _context.SaveChanges();
            return customer2BDeleted;
        }

        public List<Model.Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().Select(x => _mapper.ParseCustomer(x)).ToList();
        }

        public List<Inventory> GetInventories()
        {
            return _context.Inventories.AsNoTracking().Select(x => _mapper.ParseInventory(x)).ToList();
        }

        public List<Model.Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(x => _mapper.ParseLocation(x)).ToList();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Select(x => _mapper.ParseProduct(x)).ToList();
        }

        public Customer SearchCustomerName(string name)
        {
            return _context.Customers
            .AsNoTracking()
            .Select(x => _mapper.ParseCustomer(x))
            .ToList()
            .FirstOrDefault(x => x.CustomerName == name);
        }

        public Location SetLocation(int locationID)
        {
            return _context.Locations
            .AsNoTracking()
            .Select(x => _mapper.ParseLocation(x))
            .ToList()
            .FirstOrDefault(x => x.LocationID == locationID);
        }

        public void UpdateInventory(Order newOrder)
        {
            /* IEnumerable<Model.Inventory> inventory = _context.Inventories.AsNoTracking().Select(x => _mapper.ParseInventory(x)).ToList().Where(x => x.LocationID == newOrder.LocationID);
            foreach (var item in inventory)
            {
                foreach (var orderItem in newOrder.OrderItems)
                {
                    if(orderItem.OrderItemID == item.ProductID)
                    {
                        item.InventoryQuantity -= orderItem.OrderQuantity;
                    }
                }
            } */
            int locationID = (int)newOrder.LocationID;
            foreach (var item in newOrder.OrderItems)
            {
                var product = _context.Inventories.Single(x => x.InventoryLocation == locationID && x.InventoryProduct == item.OrderItemID);
                product.Quantity -= item.OrderQuantity;
                _context.SaveChanges();
            }
            
        }
    }
}