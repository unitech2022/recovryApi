using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Core;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;
using DiscoveryZoneApi.ViewModels;

namespace DiscoveryZoneApi.Serveries.SubscriptionsService
{
    public interface ISubscriptionsService : BaseInterface


    {
        // Task<ResponseSubscriptionDetails> GetSubscriptionDetails(int SubscriptionId,string userId);

        Task<List<Subscription>> SearchSubscription(string textSearch);

        Task<dynamic> DetailsSubscription(int SubscriptionId);
         Task<BaseResponse> GetSubscriptionsByCardId(int cardId,int page);

        //  Task<BaseResponse> GetSubscriptionsByCategoryId(int categoryId,int page);

        Task<Subscription> UpdateSubscription(Subscription Subscription);




    }


}