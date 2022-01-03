using MarketBrosuru.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Data
{
    public class DataCollection:IDataCollection
    {
        private readonly IHostingEnvironment hostingEnvironment;
        public List<Brosur> Brosurler { get; set; }
        public DataCollection(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            var filepath = Path.Combine(hostingEnvironment.ContentRootPath, "Data", "bros.json");
            string json = System.IO.File.ReadAllText(filepath);
            Brosurler = JsonConvert.DeserializeObject<List<Brosur>>(json);
        }

        public List<Brosur> Get()
        {
            return Brosurler;
        }
    }
}
