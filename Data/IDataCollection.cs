using MarketBrosuru.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketBrosuru.Data
{
    public interface IDataCollection
    {
        public List<Brosur> Get();
    }
}
