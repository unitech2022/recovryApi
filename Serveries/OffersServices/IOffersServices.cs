using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Core;
using DiscoveryZoneApi.Models;

namespace DiscoveryZoneApi.Serveries.OffersServices
{
    public interface IOffersServices :BaseInterface
    {
        //  Task<AlertResponse> GetAlertsByUserId(string userId);
        //   Task<dynamic> ViewedAlert(string userId,int alertId);

          Task<Offer> UpdateOfferStatus(int status, int id);
             Task<Offer> UpdateOffer(string image,string DescAr,int order, int id);
    }
}