using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.ViewModels;

namespace DiscoveryZoneApi.Models
{
  public class ResponseHomeUser
  {


    public List<Field>? Fields { get; set; }

    public List<Offer>? Offers { get; set; }

     public string? CodeMarkets { get; set; }

       public string? CallUsNumber { get; set; }

        public string? CardDetails { get; set; }
        

  }

}



