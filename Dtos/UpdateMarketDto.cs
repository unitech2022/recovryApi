using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Dtos
{
    public class UpdateMarketDto
    {
        public int FieldId { get; set; }
        public int CategoryId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEng { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? AboutAr { get; set; }
        public string? AboutEng { get; set; }
        public string? Images { get; set; }
        public string? LogoImage { get; set; }
        public int Order { get; set; }
        public string? Link { get; set; }

        public int CardId { get; set; }
        public double Rate { get; set; }

        public int Status { get; set; }


    }
}