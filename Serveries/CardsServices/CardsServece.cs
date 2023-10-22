using System.Text.Json;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DiscoveryZoneApi.Data;
using DiscoveryZoneApi.Models;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using DiscoveryZoneApi.Models.BaseEntity;

using X.PagedList;
using DiscoveryZoneApi.ViewModels;

namespace DiscoveryZoneApi.Serveries.CardsServices
{
    public class CardsService : ICardsService

    {


        private readonly IMapper _mapper;

        private readonly IConfiguration _config;
        private readonly AppDBcontext _context;

        public CardsService(IMapper mapper, IConfiguration config, AppDBcontext context)
        {
            _mapper = mapper;
            _config = config;
            _context = context;
        }

        public async Task<Card> AddCard(Card Card)
        {

            await _context.Cards!.AddAsync(Card);

            await _context.SaveChangesAsync();

            return Card;

        }


        public async Task<BaseResponse> GetCards(string UserId, int page)
        {
            List<Card> Cards = await _context.Cards!.ToListAsync();



            var pageResults = 10f;
            var pageCount = Math.Ceiling(Cards.Count() / pageResults);

            var items = await Cards
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;

        }

        public async Task<Card> GitCardById(int CardId)
        {

            Card? Card = await _context.Cards!.FirstOrDefaultAsync(x => x.Id == CardId);
            return Card!;
        }

        public void UpdateCard(Card Card)
        {


            // nothing

        }

        public async Task<Card> DeleteCard(int CardId)
        {
            Card? Card = await _context.Cards!.FirstOrDefaultAsync(x => x.Id == CardId);

            if (Card != null)
            {
                _context.Cards!.Remove(Card);

                await _context.SaveChangesAsync();
            }

            return Card!;
        }


        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public async Task<dynamic> GetAllCards()
        {
            List<Card> Cards = await _context.Cards!.ToListAsync();
            return Cards;
        }

        public async Task<CardResponse> GetCardUser(string userId)
        {
             UserDetailResponse userDetailResponse =new();
            bool IsSubscription =false;
            Card? card = _context.Cards!.ToList().First();
            Subscription? subscription = await _context.Subscriptions!.
            FirstOrDefaultAsync(t => t.UserId == userId && t.Status == 0 && t.CardId == card.Id);
            if(userId!=null || userId != ""){
                User? user=await _context.Users.FirstOrDefaultAsync(t=> t.Id==userId);

                 userDetailResponse =_mapper.Map<UserDetailResponse>(user);
            }
            if(subscription==null){
                IsSubscription=false;
            }else{
                  IsSubscription=true;
            }
            return new CardResponse{ 
                Card =card,
                subscription =subscription,
                isSSubscribe=IsSubscription,
                UserDetailResponse=userDetailResponse
            };

        }
    }
}