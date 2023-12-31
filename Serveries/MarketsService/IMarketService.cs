using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Core;
using DiscoveryZoneApi.Dtos;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;
using DiscoveryZoneApi.ViewModels;

namespace DiscoveryZoneApi.Serveries.MarketsService
{
    public interface IMarketsService : BaseInterface


    {
        // Task<ResponseMarketDetails> GetMarketDetails(int marketId,string userId);

        Task<List<MarketResponse>> SearchMarket(string textSearch,int type);

        Task<dynamic> DetailsMarket(int marketId);
        Task<BaseResponse> GetMarketsByFieldId(int fieldId,int page);

         Task<BaseResponse> GetMarketsByCategoryId(int categoryId,int page);

        Task<Market> UpdateMarket(UpdateMarketDto updateMarketDto, int id);

          Task<Market> UpdateMarketStatus(int status, int id);




    }


}