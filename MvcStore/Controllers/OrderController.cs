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
    public class OrderController : Controller
    {
        private readonly IStoreBL _storeBL;
        private readonly IMapper _mapper;
        public OrderController(IStoreBL storeBL,IMapper mapper )
        {
            _storeBL = storeBL;
            _mapper = mapper;
        }

        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View();
        }
    }
}