using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Models
{
    public class Brosur
    {
        public string Brand { get; set; }
        public string Code { get; set; }
        public List<Campaign> Campaigns { get; set; }
    }

    public class Campaign
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public dynamic Texts { get; set; }
    }

}
