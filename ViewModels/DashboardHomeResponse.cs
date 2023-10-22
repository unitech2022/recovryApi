using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.ViewModels;

namespace   DiscoveryZoneApi.ViewModels
{
    public class DashboardHomeResponse
    {
        public int Offers { get; set; }

        public int Fields { get; set; }

        public int Categories { get; set; }
     

        public int Markets { get; set; }

        public List<SubscriptionsResponse>? LastSubscriptions { get; set; }


        public UserDetailResponse? AdminDetails { get; set; }
    }
}

  public class SubscriptionsResponse
  {


    public Subscription? Subscription { get; set; }

    public Card? Card { get; set; }

  }

