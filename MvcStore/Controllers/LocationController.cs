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

namespace MvcStore.Controllers
{
    public class LocationController : Controller
    {
        private readonly IStoreBL _storeBL;
        private readonly IMapper _mapper;
        private readonly ILogger<LocationController> _logger;
        public LocationController(IStoreBL storeBL, IMapper mapper, ILogger<LocationController> logger)
        {
            _storeBL = storeBL;
            _mapper = mapper;
            _logger = logger;
        }
        
        public ActionResult Index()
        {
            return View(_storeBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult Details(int Id)
        {
            HttpContext.Session.SetInt32("LocationID", Id);
            return View(_storeBL.GetInventories(Id).Select(inventory => _mapper.cast2LocationIVM(inventory)).ToList());
        }
        public ActionResult Manager(int Id)
        {
            return View(_storeBL.GetInventories(Id).Select(inventory => _mapper.cast2LocationIVM(inventory)).ToList());
        }

        public ActionResult Edit(int Id)
        {
            return View(_mapper.cast2LocationEditVM(_storeBL.GetInventory(Id)));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationEditVM inventory2BUpdated)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    _storeBL.UpdateInventory(_mapper.cast2Inventory(inventory2BUpdated));
                    return RedirectToAction(nameof(Index));
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