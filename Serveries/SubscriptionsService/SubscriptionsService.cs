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



namespace DiscoveryZoneApi.Serveries.SubscriptionsService
{
    public class SubscriptionsService : ISubscriptionsService
    {

        private readonly AppDBcontext _context;
        private IMapper _mapper;

        public SubscriptionsService(AppDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<dynamic> AddAsync(dynamic type)
        {
            await _context.Subscriptions!.AddAsync(type);

            await _context.SaveChangesAsync();

            return type;

        }

        public async Task<dynamic> DeleteAsync(int typeId)
        {
            Subscription? Subscription = await _context.Subscriptions!.FirstOrDefaultAsync(x => x.Id == typeId);

            if (Subscription != null)
            {
                _context.Subscriptions!.Remove(Subscription);

                await _context.SaveChangesAsync();
            }

            return Subscription!;
        }

        public async Task<dynamic> GetItems(int page)
        {
            List<Subscription> Subscriptions = await _context.Subscriptions!.ToListAsync();
             var pageResults = 15f;
            var pageCount = Math.Ceiling(Subscriptions.Count() / pageResults);

            var items = await Subscriptions
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();



            BaseResponse baseResponse = new BaseResponse
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };
            return Subscriptions;
        }

        // public async Task<ResponseSubscriptionDetails> GetSubscriptionDetails(int SubscriptionId, string userId)
        // {


        //     // List<Product> allproduct=new  List<Product>();
        //     Subscription? Subscription = await _context.Subscriptions!.FirstOrDefaultAsync(x => x.Id == SubscriptionId);
        //     List<Product> products = await _context.Products!.Where(x => x.restaurantId == SubscriptionId).ToListAsync();
        //     List<Category> categories = await _context.Categories!.ToListAsync();
        //     foreach (Product item in products)
        //     {
        //         Cart? cart = await _context.Carts!.FirstOrDefaultAsync(t => t.ProductId == item.Id && t.UserId == userId);
        //         if (cart != null)
        //         {
        //             item.IsCart = true;
        //         }


        //     }
        //     ResponseSubscriptionDetails responseSubscriptionDetails = new ResponseSubscriptionDetails
        //     {
        //         Subscription = Subscription,
        //         Products = products,
        //         Categories = categories
        //     };

        //     return responseSubscriptionDetails;

        // }



        public async Task<List<Subscription>> SearchSubscription(string textSearch)
        {

            List<Subscription> Subscriptions = new List<Subscription>();
            List<Subscription> allSubscriptions = await _context.Subscriptions!.Where(p => p.FirstName!.Contains(textSearch) && p.Status != 1).ToListAsync();
            // Address? userAddress = await _context.Subscriptions!.FirstOrDefaultAsync(x => x.Id == AddressId);
            // foreach (var Subscription in allSubscriptions)
            // {


            return allSubscriptions;

        }

        public async Task<dynamic> GitById(int typeId)
        {
            Subscription? Subscription = await _context.Subscriptions!.FirstOrDefaultAsync(x => x.Id == typeId);
            return Subscription!;
        }



        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(dynamic category)
        {
            throw new NotImplementedException();
        }




        public async Task<dynamic> DetailsSubscription(int SubscriptionId, string userId)
        {
            List<Category> categories = new List<Category> { };
            Subscription? Subscription = await _context.Subscriptions!.FirstOrDefaultAsync(t => t.Id == SubscriptionId);





            //** rate Subscription


            categories = await _context.Categories!.ToListAsync();







            return new
            {
                Subscription = Subscription,

                categories = categories,

            };
            //   List<int> idsCategories=Subscription.CategoryId.s
        }

        public async Task<Subscription> UpdateSubscription(Subscription Subscription)
        {
            Subscription? Subscription1 = await _context.Subscriptions!.FirstOrDefaultAsync(t => t.Id == Subscription.Id);
            if (Subscription1 != null)
            {

                // if (Subscription.Email != null)
                // {
                //     Subscription1.Email = Subscription.Email;
                // }



                // if (Subscription.CategoryId != Subscription1.CategoryId)
                // {
                //     Subscription1.CategoryId = Subscription.CategoryId;
                // }



                await _context.SaveChangesAsync();


            }
            return Subscription1!;
        }

        public Task<dynamic> DetailsSubscription(int SubscriptionId)
        {
            throw new NotImplementedException();
        }


        public async Task<BaseResponse> GetSubscriptionsByCardId(int cardId, int page)
        {



            List<Subscription> Subscriptions = await _context.Subscriptions!.OrderByDescending(t => t.CreatedAt).Where(t => t.CardId == cardId).ToListAsync();



            var pageResults = 20f;
            var pageCount = Math.Ceiling(Subscriptions.Count() / pageResults);

            var items = await Subscriptions
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



        // public async Task<BaseResponse> GetSubscriptionsByCategoryId(int categoryId, int page)
        // {
        //     List<Subscription> Subscriptions = await _context.Subscriptions!.OrderBy(t => t.Order).Where(t => t.CategoryId == categoryId).ToListAsync();


        //     var pageResults = 15f;
        //     var pageCount = Math.Ceiling(Subscriptions.Count() / pageResults);

        //     var items = await Subscriptions
        //         .Skip((page - 1) * (int)pageResults)
        //         .Take((int)pageResults)
        //         .ToListAsync();



        //     BaseResponse baseResponse = new BaseResponse
        //     {
        //         Items = items,
        //         CurrentPage = page,
        //         TotalPages = (int)pageCount
        //     };

        //     return baseResponse;




        // }
   
   
    }
}