using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Dtos
{
    public class UpdateCardDto
    {
         public string? Image { get; set; }
        public string? NameAr { get; set; }

         public string? NameEng { get; set; }
        public int Order { get; set; }

        public string? Link { get; set; }

        public int Status { get; set; }
    }
}