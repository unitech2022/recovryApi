using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Serveries.HomeService;

using Microsoft.AspNetCore.Mvc;


namespace HatlliApi.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
         private readonly IHomeService _repository;
         
        private IMapper _mapper;

        public HomeController(IHomeService repository, IMapper mapper)
        {
            _repository = repository;
    
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-home-data")]
        public async Task<ActionResult> GetFields()
        {

            return Ok(await _repository.GetHomeUserData());
        }


        //  [HttpGet]
        // [Route("get-home-provider")]
        // public async Task<ActionResult> GetHomeDataProvider([FromQuery] string UserId)
        // {
        //     // Provider? provider =await _repositoryProvider.GitProviderByUserId(UserId);
        //     // if(provider ==null){
        //     //     return NotFound();
        //     // }

        //     return Ok(await _repository.GetHomeDataProvider(UserId));
        // }

    }
}