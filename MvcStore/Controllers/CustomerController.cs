using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStore.Models;
using StoreBL;

namespace MvcStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IStoreBL _storeBL;
        private readonly IMapper _mapper;
        public CustomerController(IStoreBL storeBL, IMapper mapper)
        {
            _storeBL = storeBL;
            _mapper = mapper;
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
        //GET: CustomerController/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
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
            _storeBL.DeleteCustomer(_storeBL.SearchCustomerName(name));
            return RedirectToAction(nameof(Index));
        }
    }
}