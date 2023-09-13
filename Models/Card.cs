using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string? Image { get; set; }
        public string? NameAr { get; set; }

         public string? NameEng { get; set; }
        public int Order { get; set; }

        public string? Link { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Card()
        {

            CreatedAt = DateTime.Now;

        }
    }
}