using MarketBrosuru.Data;
using MarketBrosuru.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostingEnvironment hosting;
        private readonly IDataCollection dataCollection;

        public HomeController(ILogger<HomeController> logger, IHostingEnvironment hosting, IDataCollection dataCollection)
        {
            _logger = logger;
            this.hosting = hosting;
            this.dataCollection = dataCollection;
        }

        public IActionResult Index()
        {
            var data = dataCollection.Get();
            return View(data);
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
