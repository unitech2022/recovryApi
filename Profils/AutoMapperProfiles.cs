using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoveryZoneApi.Dtos;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.ViewModels;

namespace DiscoveryZoneApi.Profils
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForRegister, User>();
            CreateMap<User, UserDetailResponse>();

           CreateMap<UpdateFieldDto, Field>();
            // CreateMap<UpdateSettingDto, Setting>();

           CreateMap<UpdateCategoryDto, Category>();
           CreateMap<UpdateMarketDto, Market>();
             CreateMap<UpdateCardDto, Card>();
            //  CreateMap<Cart, Cart>();
            // CreateMap<UpdateOrderItemDto, OrderItem>();
            // CreateMap<UpdateProductOptionsDto, ProductsOption>();
            // CreateMap<UpdateOrderItemOptionDto, OrderItemOption>();
            // CreateMap<UpdateAddressDto, Address>();
            // CreateMap<UpdateAlertDto, Alert>();
            // CreateMap<UpdateAppConfigDto, AppConfig>();

        }
    }
}