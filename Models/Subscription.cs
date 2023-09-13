using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int  CardId { get; set; }
        public string? FirstName { get; set; }

         public string? LastName { get; set; }
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public Subscription()
        {

            CreatedAt = DateTime.Now;

        }

    }
}