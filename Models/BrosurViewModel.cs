using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Models
{
    public class BrosurViewModel
    {
        public string Brand { get; set; }
        public string Code { get; set; }
        public string Contents { get; set; }
        public string Campaign { get; set; }
        public string Texts { get; set; }
        public string[] ImagePaths { get; set; }
    }
}
