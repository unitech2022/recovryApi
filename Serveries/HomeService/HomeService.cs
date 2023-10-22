using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.Data;
using AutoMapper;
using DiscoveryZoneApi.Models;
using Microsoft.EntityFrameworkCore;
using DiscoveryZoneApi.ViewModels;
using X.PagedList;


namespace DiscoveryZoneApi.Serveries.HomeService
{

    public class HomeService : IHomeService
    {

        private readonly IMapper _mapper;

        private readonly AppDBcontext _context;

        public HomeService(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;
            _context = context;
        }



        // public async Task<ResponseHomeProvider> GetHomeDataProvider(string UserId)
        // {
        //     List<OrderHome> orders = new List<OrderHome> { };
        //     List<Product> products = new List<Product> { };
        //     //** address
        //     Address? address = await _context.Addresses!.FirstOrDefaultAsync(t => t.UserId == UserId);
        //     //** user
        //     User? user = await _context.Users!.FirstOrDefaultAsync(t => t.Id == UserId);
        //     UserDetailResponse userDetail = _mapper.Map<UserDetailResponse>(user);

        //     List<Alert> alerts = await _context.Alerts!.Where(t => t.UserId == UserId && !t.Viewed).ToListAsync();
        //     //** provider
        //     Provider? provider = await _context.Providers!.FirstOrDefaultAsync(t => t.UserId == UserId);

        //     //** categories
        //     List<Category> categories = await _context.Categories!.ToListAsync();

        //     if (provider != null)
        //     {
        //         //** products
        //         products = await _context.Products!.OrderByDescending(t=> t.CreatedAt).Where(t => t.ProviderId == provider!.Id).ToListAsync();

        //         // ** orders 

        //         List<Order> allOrders = await _context.Orders!.OrderByDescending(t=> t.CreatedAt).Where(t => t.ProviderId == provider!.Id).ToListAsync();

        //         foreach (var item in allOrders)
        //         {
        //             User? userOrder = await _context.Users!.FirstOrDefaultAsync(t => t.Id == item.UserId);
        //             Address? addressUser = await _context.Addresses!.FirstOrDefaultAsync(t => t.UserId == item.UserId);
        //             orders.Add(new OrderHome
        //             {
        //                 order = item,
        //                 name = userOrder!.FullName,
        //                 imageUrl = userOrder.ProfileImage,
        //                 address = addressUser

        //             });

        //         }
        //     }


        //     return new ResponseHomeProvider
        //     {
        //         orders = orders,
        //         Products = products.Take(10).ToList(),
        //         provider = provider,
        //         user = userDetail,
        //         address = address,
        //         NotiyCount = alerts.Count(),
        //         categories = categories
        //     };


        // }

        public async Task<ResponseHomeUser> GetHomeUserData()
        {

            //** categories
            List<Field> fields = await _context.Fields!.OrderBy(t => t.Order).ToListAsync();
            //** get user

            List<Offer> offers = await _context.Offers!.OrderBy(t => t.Order).ToListAsync();

            Setting? setting = await _context.Settings!.FirstOrDefaultAsync(t => t.Name == "كود الدخول الي المتاجر"); ;

            Setting? settingCallUs = await _context.Settings!.FirstOrDefaultAsync(t => t.Name == "رقم التواصل");

            Setting? settingCardDetails = await _context.Settings!.FirstOrDefaultAsync(t => t.Name == "تفاصيل الكارد"); ;


            return new ResponseHomeUser
            {
                Fields = fields,
                Offers = offers,
                CodeMarkets = setting!.Value
                ,
                CallUsNumber = settingCallUs!.Value,
                CardDetails = settingCardDetails!.Value

            };



        }


    }
}