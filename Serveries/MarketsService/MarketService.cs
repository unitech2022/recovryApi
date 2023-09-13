using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DiscoveryZoneApi.Data;

using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Models.BaseEntity;
using DiscoveryZoneApi.ViewModels;
using X.PagedList;



namespace DiscoveryZoneApi.Serveries.MarketsService
{
    public class MarketsService : IMarketsService
    {

        private readonly AppDBcontext _context;
        private IMapper _mapper;

        public MarketsService(AppDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Markets!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;

        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Market? market = await _context.Markets!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (market != null)
            {
                _context.Markets!.Remove(market);

                await _context.SaveChangesAsync();
            }

            return market!;
        }

        public async Task<dynamic> GetItems(int page)
        {
            List<Market> Markets = await _context.Markets!.ToListAsync();
            return Markets;
        }

        // public async Task<ResponseMarketDetails> GetMarketDetails(int marketId, string userId)
        // {


        //     // List<Product> allproduct=new  List<Product>();
        //     Market? market = await _context.Markets!.FirstOrDefaultAsync(x => x.Id == marketId);
        //     List<Product> products = await _context.Products!.Where(x => x.restaurantId == marketId).ToListAsync();
        //     List<Category> categories = await _context.Categories!.ToListAsync();
        //     foreach (Product item in products)
        //     {
        //         Cart? cart = await _context.Carts!.FirstOrDefaultAsync(t => t.ProductId == item.Id && t.UserId == userId);
        //         if (cart != null)
        //         {
        //             item.IsCart = true;
        //         }


        //     }
        //     ResponseMarketDetails responseMarketDetails = new ResponseMarketDetails
        //     {
        //         Market = market,
        //         Products = products,
        //         Categories = categories
        //     };

        //     return responseMarketDetails;

        // }



        public async Task<List<Market>> SearchMarket(string textSearch)
        {

            List<Market> markets = new List<Market>();
            List<Market> allMarkets = await _context.Markets!.Where(p => p.NameAr!.Contains(textSearch) && p.Status != 1).ToListAsync();
            // Address? userAddress = await _context.Markets!.FirstOrDefaultAsync(x => x.Id == AddressId);
            // foreach (var market in allMarkets)
            // {


            return allMarkets;

        }

        public async Task<dynamic> GitById(int typeId)
        {
            Market? Market = await _context.Markets!.FirstOrDefaultAsync(x => x.Id == typeId);
            return Market!;
        }



        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(dynamic category)
        {
            throw new NotImplementedException();
        }




        public async Task<dynamic> DetailsMarket(int MarketId, string userId)
        {
            List<Category> categories = new List<Category> { };
            Market? Market = await _context.Markets!.FirstOrDefaultAsync(t => t.Id == MarketId);





            //** rate Market


            categories = await _context.Categories!.ToListAsync();







            return new
            {
                Market = Market,

                categories = categories,

            };
            //   List<int> idsCategories=Market.CategoryId.s
        }

        public async Task<Market> UpdateMarket(Market Market)
        {
            Market? Market1 = await _context.Markets!.FirstOrDefaultAsync(t => t.Id == Market.Id);
            if (Market1 != null)
            {

                if (Market.Email != null)
                {
                    Market1.Email = Market.Email;
                }



                if (Market.CategoryId != Market1.CategoryId)
                {
                    Market1.CategoryId = Market.CategoryId;
                }



                await _context.SaveChangesAsync();


            }
            return Market1!;
        }

        public Task<dynamic> DetailsMarket(int marketId)
        {
            throw new NotImplementedException();
        }


        public async Task<BaseResponse> GetMarketsByFieldId(int fieldId, int page)
        {



            List<Market> Markets = await _context.Markets!.OrderBy(t => t.Order).Where(t => t.FieldId == fieldId).ToListAsync();



            var pageResults = 15f;
            var pageCount = Math.Ceiling(Markets.Count() / pageResults);

            var items = await Markets
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



        public async Task<BaseResponse> GetMarketsByCategoryId(int categoryId, int page)
        {
            List<Market> Markets = await _context.Markets!.OrderBy(t => t.Order).Where(t => t.CategoryId == categoryId).ToListAsync();


            var pageResults = 15f;
            var pageCount = Math.Ceiling(Markets.Count() / pageResults);

            var items = await Markets
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
    }
}