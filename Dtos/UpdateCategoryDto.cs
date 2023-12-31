using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Dtos
{
    public class UpdateCategoryDto
    {
        public string? NameAr { get; set; }
        public int FieldId { get; set; }
        public int Order { get; set; }
        public string? NameEng { get; set; }
        public string? ImageUrl { get; set; }
        public int Status { get; set; }
    }
}