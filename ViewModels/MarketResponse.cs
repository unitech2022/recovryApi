using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Models;

namespace DiscoveryZoneApi.ViewModels
{
    public class MarketResponse
    {
        public Market? market { get; set; }

        public Card? card { get; set; }
    }
}