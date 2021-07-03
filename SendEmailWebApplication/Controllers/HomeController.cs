using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendEmailWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SendEmailWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Service service;
        public HomeController(ILogger<HomeController> logger, Service service)
        {
            _logger = logger;
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SendEmailDefault()
        {
            service.SendEmailDefault();
            return RedirectToAction("Index");
        }

        public IActionResult SendEmailCustom()
        {
            service.SendEmailCustom();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
