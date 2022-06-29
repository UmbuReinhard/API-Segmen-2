using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class LatihanController : Controller
    {
        private readonly ILogger<LatihanController> _logger;

        public LatihanController(ILogger<LatihanController> logger)
        {
            _logger = logger;
        }
        [Authorize(Roles = "Manager,Directur")]
        public IActionResult Index()
        {
            return View();
        }

    
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet("Unauthorized/")]
        public IActionResult Unauthorized()
        {
            return View("401");
        }
        [HttpGet("Forbidden/")]
        public IActionResult Forbidden()
        {
            return View("403");
        }


        [HttpGet("NotFound/")]
        public IActionResult NotFound()
        {
            return View("404");
        }


    }
}
