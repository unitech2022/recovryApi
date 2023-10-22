using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Data;

using DiscoveryZoneApi.Models.BaseEntity;

using Microsoft.EntityFrameworkCore;
using X.PagedList;



namespace DiscoveryZoneApi.Serveries.DashboardServices
{
    public class DashboardServices : IDashboardServices
    {
        private readonly IMapper _mapper;


        private readonly AppDBcontext _context;

        public DashboardServices(IMapper mapper, AppDBcontext context)
        {
            _mapper = mapper;

            _context = context;
        }

        public async Task<DashboardHomeResponse> GetHomeDashboard(string userId)
        {
            List<SubscriptionsResponse> lastSubscriptions = new() { };
            User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == userId);

            int fields = _context.Fields!.ToList().Count;
            int categories = _context.Categories!.ToList().Count;
            int offers = _context.Offers!.ToList().Count;
            int markets = _context.Markets!.ToList().Count;



            List<Subscription> subscriptions = await _context.Subscriptions!.OrderByDescending(t => t.CreatedAt).ToListAsync();
            foreach (var item in subscriptions)
            {
                Card? card = await _context.Cards!.FirstOrDefaultAsync(t => t.Id == item.CardId);
                lastSubscriptions.Add(new SubscriptionsResponse
                {
                    Card = card,
                    Subscription = item
                });

            }


            UserDetailResponse adminUser = _mapper.Map<UserDetailResponse>(user);
            DashboardHomeResponse dashboardHomeResponse = new()
            {
                AdminDetails = adminUser,
                Offers = offers,
                Fields = fields,
                Markets = markets,
                Categories = categories,
                LastSubscriptions = lastSubscriptions,


            };
            return dashboardHomeResponse;

        }

        // public async Task<BaseResponse> GetProducts(int page, string textSearch)
        // {
        //     List<ProductResponseAdmin> products = new List<ProductResponseAdmin>();
        //     List<Product> allProducts = new List<Product>();
        //     if (textSearch == "not" || textSearch == null)
        //     {
        //         allProducts = await _context.Products!.ToListAsync();
        //     }
        //     else
        //     {
        //         allProducts = await _context.Products!.Where(t => t.Name!.Contains(textSearch)).ToListAsync();
        //     }

        //     foreach (var item in allProducts)
        //     {
        //         Provider? provider = await _context.Providers!.FirstOrDefaultAsync(t => t.Id == item.ProviderId);

        //         products.Add(new ProductResponseAdmin
        //         {
        //             provider = provider,
        //             product = item
        //         });


        //     }

        //     var pageResults = 30f;
        //     var pageCount = Math.Ceiling(products.Count() / pageResults);

        //     var items = await products
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

        // public async Task<BaseResponse> GetProviders(int page, string textSearch)
        // {
        //     List<ProviderResponseDashBoard> providerResponseDashBoards = new List<ProviderResponseDashBoard>();
        //     List<Provider> providers = new List<Provider>();

        //     if (textSearch == "not" || textSearch == null)
        //     {
        //         providers = await _context.Providers!.ToListAsync();
        //     }
        //     else
        //     {
        //         providers = await _context.Providers!.Where(t => t.Title!.Contains(textSearch)).ToListAsync();
        //     }

        //     foreach (var item in providers)
        //     {
        //         User? user1 = await _context.Users.FirstOrDefaultAsync(t => t.Id == item.UserId);
        //         UserDetailResponse userDetails = _mapper.Map<UserDetailResponse>(user1);

        //         providerResponseDashBoards.Add(new ProviderResponseDashBoard
        //         {
        //             provider = item,
        //             userDetail = userDetails
        //         });
        //     }


        //     var pageResults = 30f;
        //     var pageCount = Math.Ceiling(providerResponseDashBoards.Count() / pageResults);

        //     var items = await providerResponseDashBoards
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

        // public async Task<object> UpdateStatusProvider(int providerId, int status)
        // {
        //     Provider? provider = await _context.Providers!.FirstOrDefaultAsync(t => t.Id == providerId);
        //     if (provider != null)
        //     {
        //         provider.Status = status;
        //         await _context.SaveChangesAsync();
        //     }
        //     return provider!;
        // }

        // public async Task<object> UpdateStatusProduct(int productId, int status)
        // {
        //     Product? product = await _context.Products!.FirstOrDefaultAsync(t => t.Id == productId);
        //     if (product != null)
        //     {
        //         product.Status = status;
        //         await _context.SaveChangesAsync();
        //     }
        //     return product!;
        // }

        // public async Task<BaseResponse> GetOrders(int page)
        // {
        //     List<OrderResponseAdmin> orders = new List<OrderResponseAdmin>();


        //     List<Order> allOrders = await _context.Orders!.ToListAsync();


        //     foreach (var item in allOrders)
        //     {
        //         Provider? provider = await _context.Providers!.FirstOrDefaultAsync(t => t.Id == item.ProviderId);

        //         orders.Add(new OrderResponseAdmin
        //         {
        //             Provider = provider,
        //             order = item
        //         });


        //     }

        //     var pageResults = 30f;
        //     var pageCount = Math.Ceiling(orders.Count() / pageResults);

        //     var items = await orders
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

        public async Task<BaseResponse> GetField(int page, string textSearch)
        {




            List<Field> allFields = new();
            if (textSearch == "not" || textSearch == null)
            {
                allFields = await _context.Fields!.OrderBy(t => t.Order).ToListAsync();
            }
            else
            {
                allFields = await _context.Fields!.OrderBy(t => t.Order).Where(t => t.NameAr!.Contains(textSearch)).ToListAsync();
            }



            var pageResults = 30f;
            var pageCount = Math.Ceiling(allFields.Count / pageResults);

            var items = await allFields
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            BaseResponse baseResponse = new()
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }




        // public async Task<BaseResponse> GetWallets(int page)
        // {
        //     List<WalletResponse> walletResponses = new List<WalletResponse>();
        //     List<OrderWallet> orderWallets = await _context.OrderWallets!.OrderByDescending(t => t.CreatedAt).ToListAsync();

        //     foreach (var item in orderWallets)
        //     {
        //         Provider? provider = await _context.Providers!.FirstOrDefaultAsync(t => t.UserId == item.UserId);
        //         User? user = await _context.Users!.FirstOrDefaultAsync(t => t.Id == item.UserId);
        //         UserDetailResponse? userDetailResponse = _mapper.Map<UserDetailResponse>(user);
        //         walletResponses.Add(new WalletResponse
        //         {
        //             wallet = item,
        //             userDetail = userDetailResponse,
        //             provider = provider
        //         });

        //     }

        //     var pageResults = 30f;
        //     var pageCount = Math.Ceiling(walletResponses.Count() / pageResults);

        //     var items = await walletResponses
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

        // public async Task<object> UpdateStatusWallet(int walletId, int status)
        // {
        //     OrderWallet? wallet = await _context.OrderWallets!.FirstOrDefaultAsync(t => t.Id == walletId);
        //     if (wallet != null)
        //     {
        //         wallet.Status = status;
        //         await _context.SaveChangesAsync();
        //     }
        //     return wallet!;
        // }

        public async Task<BaseResponse> GetCategories(int page, string textSearch)
        {
            List<ResponseCategoryDashboard> categoryDashboards = new() { };
            List<Category> categories = new() { };

            if (textSearch == "not" || textSearch == null)
            {
                categories = await _context.Categories!.OrderBy(t => t.Order).ToListAsync();
            }
            else
            {
                categories = await _context.Categories!.OrderBy(t => t.Order).Where(t => t.NameAr!.Contains(textSearch)).ToListAsync();
            }


            foreach (var item in categories)
            {
                Field? field = await _context.Fields!.FirstOrDefaultAsync(t => t.Id == item.FieldId);
                categoryDashboards.Add(new ResponseCategoryDashboard
                {
                    category = item,
                    Field = field
                });

            }

            var pageResults = 30f;
            var pageCount = Math.Ceiling(categoryDashboards.Count / pageResults);

            var items = await categoryDashboards
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

        public async Task<BaseResponse> GetMarkets(int page, string textSearch)
        {
            List<ResponseMarketDashboard> responseMarketDashboards = new();
            List<Market> markets = new() { };
            if (textSearch == "not" || textSearch == null)
            {
                markets = await _context.Markets!.OrderBy(t => t.Order).ToListAsync();
            }
            else
            {
                markets = await _context.Markets!.OrderBy(t => t.Order).Where(t => t.NameAr!.Contains(textSearch)).ToListAsync();
            }


            foreach (var item in markets)
            {
                Field? field = await _context.Fields!.FirstOrDefaultAsync(t => t.Id == item.FieldId);
                Category? category = await _context.Categories!.FirstOrDefaultAsync(t => t.Id == item.CategoryId);

                responseMarketDashboards.Add(new ResponseMarketDashboard
                {
                    field = field,
                    category = category,
                    market = item
                });




            }


            var pageResults = 30f;
            var pageCount = Math.Ceiling(responseMarketDashboards.Count / pageResults);

            var items = await responseMarketDashboards
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            BaseResponse baseResponse = new()
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;


        }

        public async Task<List<Field>> GetFields()
        {
            List<Field> fields = await _context.Fields!.OrderBy(t => t.Order).Where(t => t.Status != 2).ToListAsync();

            return fields;
        }

        public async Task<List<Offer>> GetOffers()
        {

            List<Offer> offers = await _context.Offers!.OrderBy(t => t.Order).ToListAsync();

            return offers;
        }

        public async Task<BaseResponse> GetSubscriptions(int page, string textSearch)
        {
            List<SubscriptionsResponse> subscriptions = new();
            List<Subscription> allSubscription = new() { };
            if (textSearch == "not" || textSearch == null)
            {
                allSubscription = await _context.Subscriptions!.OrderByDescending(t => t.CreatedAt).ToListAsync();
            }
            else
            {
                allSubscription = await _context.Subscriptions!.OrderByDescending(t => t.CreatedAt).Where(t => t.FirstName!.Contains(textSearch)).ToListAsync();
            }


            foreach (var item in allSubscription)
            {
                Card? card = await _context.Cards!.FirstOrDefaultAsync(t => t.Id == item.CardId);


                subscriptions.Add(new SubscriptionsResponse
                {

                    Card = card,
                    Subscription = item
                });




            }


            var pageResults = 30f;
            var pageCount = Math.Ceiling(subscriptions.Count / pageResults);

            var items = await subscriptions
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            BaseResponse baseResponse = new()
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;

        }

        public async Task<object> UpdateStatusSubscription(int subscribeId, int status)
        {
          
            Subscription? subscription = await _context.Subscriptions!.FirstOrDefaultAsync(t => t.Id == subscribeId);

            if (subscription != null)
            {
                subscription.Status = status;
                await _context.SaveChangesAsync();
            }
            return subscription!;
        }

        public async Task<BaseResponse> GetAlerts(int page, string textSearch)
        {
             List<Alert> alAlerts = new();
            if (textSearch == "not" || textSearch == null)
            {
                alAlerts = await _context.Alerts!.OrderByDescending(t => t.CreatedAt).ToListAsync();
            }
            else
            {
                alAlerts = await _context.Alerts!.OrderByDescending(t => t.CreatedAt).Where(t => t.TitleAr!.Contains(textSearch)).ToListAsync();
            }



            var pageResults = 30f;
            var pageCount = Math.Ceiling(alAlerts.Count / pageResults);

            var items = await alAlerts
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
            BaseResponse baseResponse = new()
            {
                Items = items,
                CurrentPage = page,
                TotalPages = (int)pageCount
            };

            return baseResponse;
        }

        // public async Task<dynamic> PaymentProvider(string userId, double mony, int type)
        // {
        //     Provider? provider = await _context.Providers!.FirstOrDefaultAsync(t => t.UserId == userId);
        //     if (provider != null)
        //     {
        //         // *** minus
        //         if (type == 0)
        //         {
        //             if (mony == 0)
        //             {
        //                 provider.Wallet = 0.0;

        //             }
        //             else
        //             {
        //                 provider.Wallet = provider.Wallet - mony;

        //             }
        //             // ** add 
        //         }
        //         else
        //         {

        //             provider.Wallet = provider.Wallet + mony;
        //         }

        //     }

        //     await _context.SaveChangesAsync();
        //     return provider!;
        // }

        // public async Task<object> BlockUser(string userId, int status)
        // {
        //     User? user = await _context.Users.FirstOrDefaultAsync(t => t.Id == userId);

        //     if (user != null)
        //     {
        //         user.Status = status;
        //         if (status == 0)
        //         {
        //             await Functions.SendNotificationAsync(_context, user!.Id!, 0, "تنبيه", "تم تفعيل رقم الهاتف", "", "orders");
        //         }
        //         else
        //         {
        //             await Functions.SendNotificationAsync(_context, user!.Id!, 0, "تنبيه", "تم حظر رقم الهاتف", "", "orders");
        //         }

        //         await _context.SaveChangesAsync();
        //     }
        //     return user!;
        // }


    }
}