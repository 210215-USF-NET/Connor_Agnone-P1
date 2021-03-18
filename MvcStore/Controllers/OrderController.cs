using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using MvcStore.Models;
using StoreBL;
using StoreModels;
namespace MvcStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IStoreBL _storeBL;
        private readonly IMapper _mapper;
        private readonly ILogger<OrderController> _logger;
        private static Order cart = new Order();
        
        public OrderController(IStoreBL storeBL,IMapper mapper,ILogger<OrderController> logger )
        {
            _storeBL = storeBL;
            _mapper = mapper;
            _logger = logger;
        }

        public ActionResult Checkout()
        {
            return View(cart.OrderItems.Select(item => _mapper.cast2CheckoutVM(item)).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Checkout(CheckoutVM checkout)
        {
            
            decimal total = 0;
            foreach (var item in cart.OrderItems)
            {
                total += (item.OrderItemProduct.ProductPrice * item.OrderQuantity);
            }
            Order currentOrder = new Order{
                                OrderTotal = total,
                                OrderItems = new List<OrderItems>(),
                                OrderDate = DateTime.Now,
                                CustomerID = (int)HttpContext.Session.GetInt32("CustomerID"),
                                LocationID = (int)HttpContext.Session.GetInt32("LocationID")
                                };
            foreach (var thing in cart.OrderItems)
            {
                currentOrder.OrderItems.Add(new OrderItems{
                    OrderQuantity = thing.OrderQuantity,
                    ProductID = thing.ProductID
                });
            }

            _storeBL.CreateOrder(currentOrder);
            _storeBL.UpdateInventory(currentOrder);
            _logger.LogWarning($"User Checkout!");
            cart.OrderItems.Clear();
            return RedirectToAction("Index","Home");
            
        }
        public ActionResult Details(int Id)
        {
            return View(_mapper.cast2LocationEditVM(_storeBL.GetInventory(Id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(LocationEditVM inventory2BUpdated)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    if(cart.OrderItems == null || cart.LocationID != inventory2BUpdated.LocationId)
                    {
                        cart.OrderItems = new List<OrderItems>();
                        cart.OrderItems.Clear();
                    }
                    _logger.LogWarning($"User has added {inventory2BUpdated.ProductName} to their cart!");
                    Inventory chosenInventory = _mapper.cast2Inventory(inventory2BUpdated);
                    chosenInventory.InventoryProduct = _storeBL.GetInventory(inventory2BUpdated.InventoryId).InventoryProduct;
                    OrderItems currentItem = new OrderItems{
                                                OrderQuantity = chosenInventory.InventoryQuantity,
                                                OrderItemProduct = chosenInventory.InventoryProduct,
                                                ProductID = chosenInventory.InventoryProduct.Id
                                            };
                    cart.LocationID = inventory2BUpdated.LocationId;
                    cart.OrderItems.Add(currentItem);
                    return RedirectToAction("Details","Location",new {Id = (int)HttpContext.Session.GetInt32("LocationID")});
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
    }
}