using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;

namespace DiscoveryZoneApi.Serveries.CardsServices
{
    public interface ICardsService
    {
        Task<BaseResponse> GetCards(string UserId,int page);


 Task<dynamic> GetAllCards();

        Task<Card> AddCard(Card Card);

         Task<Card> GitCardById(int CardId);


        Task<Card> DeleteCard(int CardId);

        void UpdateCard(Card Card);


         bool SaveChanges();
    }
}