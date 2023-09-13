using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Core;
using DiscoveryZoneApi.Models;

using HattliApi.Models;

namespace DiscoveryZoneApi.Serveries.HomeService
{
    public interface IHomeService 
    {
          Task<ResponseHomeUser> GetHomeUserData();

          

        //    Task<ResponseHomeProvider> GetHomeDataProvider(string UserId);
    }
}