using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Models
{
    public class Subscription
    {

        public int Id { get; set; }
        public int CardId { get; set; }
public int Code { get; set; }
        public string? UserId { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public string? Address { get; set; }

        public int Status { get; set; } 
        public DateTime ExpiredDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public Subscription()
        {
            Status = 0;
            CreatedAt = DateTime.Now;
            ExpiredDate=DateTime.Now.AddYears(1);

        }

    }
}