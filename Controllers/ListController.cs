using MarketBrosuru.Data;
using MarketBrosuru.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Controllers
{
    public class ListController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private readonly IDataCollection dataCollection;

        public ListController(IHostingEnvironment hosting, IDataCollection dataCollection)
        {
            this.hosting = hosting;
            this.dataCollection = dataCollection;
        }
        public IActionResult Index(string brand)
        {
            var data = dataCollection.Get();
            var filteredBrosur = data.First(i => i.Code == brand);
            
            return View("Index", filteredBrosur);
        }
    }
}
