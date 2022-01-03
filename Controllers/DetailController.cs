using MarketBrosuru.Data;
using MarketBrosuru.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Controllers
{
    public class DetailController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private readonly IDataCollection dataCollection;

        public DetailController(IHostingEnvironment hosting, IMemoryCache memoryCache, IDataCollection dataCollection)
        {
            this.hosting = hosting;
            MemoryCache = memoryCache;
            this.dataCollection = dataCollection;
        }

        public IMemoryCache MemoryCache { get; }

        public IActionResult Index(string brand, string contents)
        {

            var cacheKey = brand+"-"+contents;
            BrosurViewModel brosurVM;
            //checks if cache entries exists
            if (!MemoryCache.TryGetValue(cacheKey, out brosurVM))
            {
                //calling the server
                var data = dataCollection.Get();
                var filtered = data.Where(i => i.Code == brand && i.Campaigns.Any(j => j.Contents == contents));
                var brosur = filtered.First();
                string dirPath = Path.Combine(hosting.WebRootPath, "img", "bros-img", brand, contents);
                var files = Directory.Exists(dirPath) ? Directory.GetFiles(dirPath) : new string[] { };
                var campaign = brosur.Campaigns.First(i => i.Contents == contents);

                brosurVM = new BrosurViewModel
                {
                    Brand = brosur.Brand,
                    Code = brosur.Code,
                    Contents = contents,
                    Campaign = campaign.Title,
                    ImagePaths = files.Where(i=>!i.Contains("thumb")).ToArray(),
                    Texts = Convert.ToString(campaign.Texts)
                };

                //setting up cache options
                var cacheExpiryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                    Priority = CacheItemPriority.High,
                    SlidingExpiration = TimeSpan.FromSeconds(20)
                };
                //setting cache entries
                MemoryCache.Set(cacheKey, brosurVM, cacheExpiryOptions);
            }

            return View("Index",brosurVM);
        }
    }
}
