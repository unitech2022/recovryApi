using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Dtos
{
    public class UpdateFieldDto
    {

           public string? Name{ get; set; }
           public string? ImageUrl { get; set; }

            public int Status { get; set; }
        
    }
}