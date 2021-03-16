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
    public class CustomerController : Controller
    {
        private readonly IStoreBL _storeBL;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;
        // public CustomerController(IStoreBL storeBL, IMapper mapper)
        // {
        //     _storeBL = storeBL;
        //     _mapper = mapper;
        // }
        public CustomerController(IStoreBL storeBL, IMapper mapper,ILogger<CustomerController> logger)
        {
            _storeBL = storeBL;
            _mapper = mapper;
            _logger = logger;
        }
        //GET: CustomerController
        public ActionResult Index()
        {
            return View(_storeBL.GetCustomers().Select(customer => _mapper.cast2CustomerIndexVM(customer)).ToList());
        }
        //GET: CustomerController/Details/5
        public ActionResult Details(string name)
        {
            return View(_mapper.cast2CustomerCRVM(_storeBL.SearchCustomerName(name)));
        }
        //POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCRVM newCustomer)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation($"Customer {newCustomer.CustomerName} has been created!");
                    _storeBL.CreateCustomer(_mapper.cast2Customer(newCustomer));
                    return RedirectToAction(nameof(Index));
                }
                catch 
                {
                    return View();
                }
            }
            return View();
        }
        public ActionResult Edit(string name)
        {
            return View(_mapper.cast2CustomerEditVM(_storeBL.SearchCustomerName(name)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerEditVM customer2BUpdated)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _logger.LogInformation($"Customer {customer2BUpdated.CustomerName} has been edited!");
                    _storeBL.UpdateCustomer(_mapper.cast2Customer(customer2BUpdated));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }
        public ActionResult Delete(string name)
        {
            _logger.LogInformation($"Customer: {name} has been deleted!");
            _storeBL.DeleteCustomer(_storeBL.SearchCustomerName(name));
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View("Login");
        }
        [HttpPost]
        public ActionResult Login(CustomerCRVM customerVM)
        {
            if (ModelState.IsValid)
            {
                _storeBL.currentCustomer = _storeBL.GetCustomerByEmail(customerVM.CustomerEmail);
                if (_storeBL.currentCustomer == null)
                {
                    return NotFound();
                }
                HttpContext.Session.SetString("CustomerEmail", _storeBL.currentCustomer.CustomerEmail);
                HttpContext.Session.SetInt32("CustomerID", _storeBL.currentCustomer.Id);
                return Redirect("/");
            }
            return BadRequest("Invalid model state");
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Remove("CustomerEmail");
            HttpContext.Session.Remove("CustomerID");
            return Redirect("/");
        }
    }
}