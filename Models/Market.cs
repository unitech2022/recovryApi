using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscoveryZoneApi.Models
{
    public class Market
    {
        public int Id { get; set; }


        public int FieldId { get; set; }
        public int CategoryId { get; set; }

        public string? NameAr { get; set; }

        public string? NameEng { get; set; }


        public string? Email { get; set; }

              public string? Phone { get; set; }
        public string? AboutAr { get; set; }

         public string? AboutEng { get; set; }
         public string? LogoImage { get; set; }
        public string? Images { get; set; }

        public int Order { get; set; }

         public string? Link { get; set; }

        // public string? NameBunk { get; set; }

        public int CardId { get; set; }

        // public double Lng { get; set; }

        public double Rate { get; set; }

        public int Status { get; set; }

        public double Discount { get; set; }

        //  public double Area { get; set; }

        // public double Distance { get; set; }

        // public double Wallet { get; set; }

        public DateTime CreatedAt { get; set; }
        public Market()
        {


            CreatedAt = DateTime.Now;

            Rate = 0.0;
            CardId=0;


        }

    }
}