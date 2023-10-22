using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Models;

namespace DiscoveryZoneApi.ViewModels
{
    public class CardResponse
    {
        public Card? Card { get; set; }

        public Subscription? subscription { get; set; }

        public UserDetailResponse? UserDetailResponse { get; set; }

        public bool isSSubscribe { get; set; }
    }
}