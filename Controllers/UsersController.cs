using DiscoveryZoneApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using DiscoveryZoneApi.Serveries;
using Newtonsoft.Json;


namespace DiscoveryZoneApi.Controllers
{


    //  dotnet commends

    // dotnet publish --configuration Release
    // migrations dotnet
    // dotnet ef migrations add InitialCreate
    // update database 
    // dotnet ef database update
    // create
    // dotnet new webapi -n name 
    public class UsersController : Controller
    {
        private readonly IUserService? _service;
        public UsersController(IUserService service)
        {
            _service = service;
        }



    

        [HttpPost("admin-signup")]
        public async Task<ActionResult> RegisterAdmin([FromForm] UserForRegister userForRegister)
        {
            dynamic result = await _service!.RegisterAdmin(userForRegister);
            return result.status == true ? (ActionResult)BadRequest(result) : (ActionResult)Ok(result);
        }


        [HttpPost("admin-login")]
        public async Task<IActionResult> LoginAdmin([FromForm] AdminForLoginRequest adminForLogin)
        {
            dynamic result = await _service!.LoginAdmin(adminForLogin);
            return result == null ? Unauthorized() : (IActionResult)Ok(result);
        }


     [HttpPost("user-signup")]
        public async Task<ActionResult> RegisterUser([FromForm] UserForRegister userForRegister)
        {
            return Ok(await _service!.RegisterUser(userForRegister));
        }


        [HttpPost("user-login")]
        public async Task<IActionResult> LoginUser([FromForm] string userName,[FromForm] string code,[FromForm] string deviceToken)
        {
           return Ok(await _service!.LoginUser(userName,code,deviceToken));
        }
   }
}

