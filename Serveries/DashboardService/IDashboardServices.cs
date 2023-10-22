using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;

namespace DiscoveryZoneApi.Serveries.DashboardServices
{
    public interface IDashboardServices
    {
        Task<DashboardHomeResponse> GetHomeDashboard(string userId);

        //  Task<object> UpdateStatusProvider(int providerId,int status);

        Task<BaseResponse> GetField(int page, string textSearch);
        Task<BaseResponse> GetCategories(int page, string textSearch);

          Task<BaseResponse> GetAlerts(int page, string textSearch);

        Task<BaseResponse> GetMarkets(int page, string textSearch);

          Task<List<Offer>> GetOffers();


        Task<List<Field>> GetFields();


          Task<BaseResponse> GetSubscriptions(int page,string textSearch);

        //     Task<BaseResponse> GetWallets(int page);

        Task<object> UpdateStatusSubscription(int subscribeId,int status);   
        //   Task<object> UpdateStatusProduct(int productId,int status);   


        //     Task<object> BlockUser(string userId,int status);   

        //     Task<BaseResponse> GetOrders(int page);

        //       Task<dynamic> PaymentProvider(string userId , double mony,int type );


    }
}