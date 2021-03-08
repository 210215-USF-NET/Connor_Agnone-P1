using System;
using StoreModels;
using StoreBL;
using System.Collections.Generic;
using System.Linq;
using Serilog;
namespace StoreUI
{
    public class LocationMenu : IMenu
    {
        private MyStoreBL _storeBL;
        public LocationMenu(MyStoreBL storeBL)
        {
            _storeBL = storeBL;
        }
        public void Start()
        {
            Boolean stay = true;
            do
            {
                Console.Clear();
                Log.Information("Connected to store");
                Console.WriteLine($"Welcome to {_storeBL.currentLocation.LocationName}, {_storeBL.currentCustomer.CustomerName}!");
                Console.WriteLine("Would you like to start an order, see our inventory, or exit?");
                Console.WriteLine("[0] Let's start an order");
                Console.WriteLine("[1] Show me the goods!");
                Console.WriteLine("[2] Exit please");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "0":
                        StartOrder();
                        break;
                    case "1":
                        GetInventory();
                        break;
                    case "2":
                        stay = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input! ");
                        break;
                }
            }while(stay);
        }
        public void StartOrder()
        {
            Log.Information("Begin Order!");
            Order newOrder = new Order
            {
                LocationID = _storeBL.currentLocation.LocationID,
                CustomerID = _storeBL.currentCustomer.CustomerID,
                OrderTotal = 0,
                OrderItems = new List<OrderItems>()
            };
            List<Inventory> newInventory = new List<Inventory>();
            foreach (var item in _storeBL.GetInventories())
            {
                if(item.LocationID == _storeBL.currentLocation.LocationID)
                {
                newInventory.Add(item);

                }
            }
            List<Product> newProucts =_storeBL.GetProducts();
            for(int i = 0; i < newProucts.Count; i++)
            {
                newInventory.ElementAt(i).InventoryProduct = newProucts.ElementAt(i);
            }
            Boolean orderNotComplete = true;
            OrderItems test = new OrderItems();
            do
            {
                Console.Clear();
                Console.WriteLine($"You're current total is: ${newOrder.OrderTotal}");
                Console.WriteLine("Enter item ID you desire. Enter 0 to get our inventory. Type 'D' to complete your order:");
                string userInput = Console.ReadLine();
                int amount = 0;
                switch (userInput)
                {
                    case "0":
                        GetInventory();
                        break;
                    case "1":
                        Console.WriteLine($"How much {newInventory.ElementAt(0).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(0).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(0).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(0).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice); 
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "2":
                        Console.WriteLine($"How much {newInventory.ElementAt(1).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(1).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(1).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(1).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "3":
                        Console.WriteLine($"How much {newInventory.ElementAt(2).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(2).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(2).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(2).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "4":
                        Console.WriteLine($"How much {newInventory.ElementAt(3).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(3).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(3).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(3).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "5":
                        Console.WriteLine($"How much {newInventory.ElementAt(4).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(4).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(4).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(4).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "6":
                        Console.WriteLine($"How much {newInventory.ElementAt(5).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(5).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(5).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(5).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "7":
                        Console.WriteLine($"How much {newInventory.ElementAt(6).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(6).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(6).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(6).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "8":
                        Console.WriteLine($"How much {newInventory.ElementAt(7).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(7).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(7).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(7).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "9":
                        Console.WriteLine($"How much {newInventory.ElementAt(8).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(8).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(8).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(8).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "10":
                        Console.WriteLine($"How much {newInventory.ElementAt(9).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(9).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(9).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(9).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "11":
                        Console.WriteLine($"How much {newInventory.ElementAt(10).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(10).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(10).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(10).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "12":
                        Console.WriteLine($"How much {newInventory.ElementAt(11).InventoryProduct.ProductName} do you want?");
                        amount = int.Parse(Console.ReadLine());
                        if(amount <= newInventory.ElementAt(11).InventoryQuantity)
                        {
                            test = new OrderItems
                            {
                                OrderItemProduct = newInventory.ElementAt(11).InventoryProduct,
                                OrderQuantity = amount,
                                OrderItemID = newInventory.ElementAt(11).InventoryProduct.ProductID
                            };
                            newOrder.OrderItems.Add(test);
                            newOrder.OrderTotal = newOrder.OrderTotal + (test.OrderQuantity * test.OrderItemProduct.ProductPrice);
                        }else
                        {
                            Console.WriteLine("We don't have that many. Please try again with a lower amount.");
                            Console.ReadLine();
                        }
                        break;
                    case "D":
                        orderNotComplete = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }while(orderNotComplete);
            Console.WriteLine($"You're total is: ${newOrder.OrderTotal}");
            newOrder.LocationID = _storeBL.currentLocation.LocationID;
            newOrder.CustomerID = _storeBL.currentCustomer.CustomerID;
            //newOrder.OrderDate = DateTime.Now;
            _storeBL.CreateOrder(newOrder);
            _storeBL.UpdateInventory(newOrder);
            Console.WriteLine("order has been submitted!");
            Log.Information("Order Submitted! Inventory should be updated to reflect!");
            _storeBL.currentCustomer.CustomerOrder = newOrder;
        }
        public void GetInventory()
        {
            Console.Clear();
            List<Product> newProucts =_storeBL.GetProducts();
            foreach(var item in _storeBL.GetInventories())
            {
                foreach(var product in newProucts)
                {
                    if(item.ProductID == product.ProductID)
                    {
                        if(item.LocationID == _storeBL.currentLocation.LocationID)
                        {
                            Console.WriteLine(item.ToString() + $"{product.ProductName} | Price: ${product.ProductPrice} | QTY: {item.InventoryQuantity}");
                        }
                    }
                }
                
            }
            Console.WriteLine("Press enter key to continue");
            Console.ReadLine();
        }
    }
}