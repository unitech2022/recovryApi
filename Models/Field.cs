using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Models
{
  public class Field
  {
    public int Id { get; set; }
    public string? NameAr { get; set; }

     public string? NameEng { get; set; }
    public string? ImageUrl { get; set; }

public int Order { get; set; }
    public int Status { get; set; }
    public DateTime CreatedAt { get; set; }

    public Field()
    {

      CreatedAt = DateTime.Now;
      Status=0;

    }
  }
}