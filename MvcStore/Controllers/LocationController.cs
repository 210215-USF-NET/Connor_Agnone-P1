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
    public class LocationController : Controller
    {
        private readonly IStoreBL _storeBL;
        private readonly IMapper _mapper;
        public LocationController(IStoreBL storeBL, IMapper mapper)
        {
            _storeBL = storeBL;
            _mapper = mapper;
        }
        
        public ActionResult Index()
        {
            return View(_storeBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult Details(int Id)
        {
            return View(_storeBL.GetInventories(Id).Select(inventory => _mapper.cast2LocationIVM(inventory)).ToList());
        }
    }
}