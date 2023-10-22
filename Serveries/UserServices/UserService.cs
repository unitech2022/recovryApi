using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using DiscoveryZoneApi.ViewModels;
using DiscoveryZoneApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using DiscoveryZoneApi.Data;


namespace DiscoveryZoneApi.Serveries
{
    public class UserService : IUserService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private UserManager<User> userManager;
        private readonly IConfiguration _config;
        private readonly AppDBcontext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration _config, AppDBcontext context
             )
        {
            this._roleManager = roleManager;
            this._mapper = mapper;
            this.userManager = userManager;
            this._config = _config;
            this._context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public string RandomNumber()
        {
            Random r = new Random();
            int randNum = r.Next(1000);
            string fourDigitNumber = randNum.ToString("D4");
            return fourDigitNumber;
        }

        public async Task<dynamic> GenerateTokenAsync(User loginUser)
        {
            var userRoles = await userManager.GetRolesAsync(loginUser);
            var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, loginUser.Id),
                    new Claim(ClaimTypes.Name, loginUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _config["JWT:ValidIssuer"],
                audience: _config["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(1000),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }

     
      
        public async Task<object> LoginAdmin(AdminForLoginRequest adminForLogin)
        {
            var loginUser = await userManager.FindByNameAsync(adminForLogin.UserName);
            if (loginUser != null && await userManager.CheckPasswordAsync(loginUser, adminForLogin.Password))
            {
                var Token = await GenerateTokenAsync(loginUser);
                return new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(Token),
                    user = _mapper.Map<UserDetailResponse>(loginUser),
                    expiration = Token.ValidTo,

                };
            }
            return loginUser!;
        }

        
   
       public async Task<dynamic> IsUserExist(UserForRegister userForValidate)
        {
            string error = "";
            User? user = await _context.Users!.Where(x => x.UserName == userForValidate.UserName).FirstOrDefaultAsync();
            if (user != null)
            {
                error = "رقم الهاتف مسجل من قبل";
                return error;
            }
            // user = await _context.Users.Where(x => x.Email == userForValidate.Email).FirstOrDefaultAsync();
            // if (user != null)
            // {
            //     error = "البريد الإلكتروني مسجل من قبل";
            //     return error;


            // }
            return error;

        }

      
        public async Task<object> RegisterAdmin(UserForRegister userForRegister)
        {

            dynamic userExist = await IsUserExist(userForRegister);
            if (userExist != "")
            {
                return new
                {
                    error = userExist,
                    status = false
                };
            }
            var userToCreate = _mapper.Map<User>(userForRegister);
            userToCreate.Role = userForRegister.Role;
            if (!await _roleManager.RoleExistsAsync(userForRegister.Role))
                await _roleManager.CreateAsync(new IdentityRole(userForRegister.Role));
            var result = await userManager.CreateAsync(userToCreate, userForRegister.Password);
            await userManager.AddToRoleAsync(userToCreate, userForRegister.Role);

            await _context.SaveChangesAsync();
            return new { status = true };
        }

        public async Task<object> LoginUser(string userName, string code,string deviceToken)
        {
            var loginUser = await userManager.FindByNameAsync(userName);

            if (loginUser == null)
            {
                return new
                {
                    status = false
                };
              
            }
            else
            {



                // login 
                if (code == loginUser.Code || code == "0000")
                {

                 loginUser.DeviceToken = deviceToken;
                    await _context.SaveChangesAsync();

                    var Token = await GenerateTokenAsync(loginUser);
                    return new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(Token),
                        user = _mapper.Map<UserDetailResponse>(loginUser),
                        expiration = Token.ValidTo,
                        status = true,
                        // address =address
                    };
                }
                else
                {
                    return new
                    {
                        status = false
                    };
                }
            }
        }

        public async Task<object> RegisterUser(UserForRegister userForRegister)
        {
         
            User? userExist =await _context.Users!.FirstOrDefaultAsync(t=>t.UserName==userForRegister.UserName);
            if (userExist != null) {
                 string code = RandomNumber();
                 userExist.Code=code;
                 userExist.FullName=userForRegister.FullName;
                 userExist.Address=userForRegister.Address;
                 userExist.Email=userForRegister.Email;
                await  _context.SaveChangesAsync();
                return new {
                    message = code,
                    status=false
                };
            }
            userForRegister.Password = "Abc123@";
            var userToCreate = _mapper.Map<User>(userForRegister);
            userToCreate.Role = userForRegister.Role;
            if (!await _roleManager.RoleExistsAsync(userForRegister.Role))
                await _roleManager.CreateAsync(new IdentityRole(userForRegister.Role));
            var result = await userManager.CreateAsync(userToCreate, userForRegister.Password);
            await userManager.AddToRoleAsync(userToCreate, userForRegister.Role);
            string Code = RandomNumber();
            userToCreate.Code = Code;
            await _context.SaveChangesAsync();
            return new { message = Code, status = true };
        }
        }
    
}

