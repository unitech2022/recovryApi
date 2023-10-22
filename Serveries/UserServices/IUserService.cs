using System;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Models;


namespace DiscoveryZoneApi.Serveries
{
    public interface IUserService
    {

        Task<object> LoginAdmin(AdminForLoginRequest adminForLogin);
        Task<object> RegisterAdmin(UserForRegister adminForRegister);

          Task<object> LoginUser(string userName,string code,string deviceToken);
        Task<object> RegisterUser(UserForRegister adminForRegister);

    }
}

