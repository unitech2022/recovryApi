using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Models
{


    public class Offer
    {
        public int Id { get; set; }
        public string? Image { get; set; }

        public int Status { get; set; }
        public string? DescAr { get; set; }
         public string? DescEng { get; set; }

        public int Order { get; set; }
        public double Discount { get; set; }

        public DateTime CreatedAt { get; set; }
        public Offer()
        {

            CreatedAt = DateTime.Now;
            Status=0;

        }
    }
}