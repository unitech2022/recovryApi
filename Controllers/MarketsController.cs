using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DiscoveryZoneApi.Models;

using DiscoveryZoneApi.Serveries.MarketsService;
using Microsoft.AspNetCore.Authorization;
using DiscoveryZoneApi.Dtos;

namespace DiscoveryZoneApi.Controllers
{
    [ApiController]
    [Route("Market")]
    public class MarketsController : ControllerBase
    {
        private readonly IMarketsService _repository;
        private IMapper _mapper;
        public MarketsController(IMarketsService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }






        [HttpPost]
        [Route("delete-Market")]
        public async Task<ActionResult> DeleteMarket([FromForm] int MarketId)
        {




            return Ok(await _repository.DeleteAsync(MarketId));
        }



        [HttpGet]
        [Route("get-Markets-by-fieldId")]
        public async Task<ActionResult> GetMarketByFieldId([FromQuery] int page, [FromQuery] int fieldId)
        {




            return Ok(await _repository.GetMarketsByFieldId(fieldId, page));
        }


        [HttpGet]
        [Route("get-Markets-by-catId")]
        public async Task<ActionResult> GetGetMarketsByCategoryId([FromQuery] int page, [FromQuery] int categoryId)
        {

            return Ok(await _repository.GetMarketsByCategoryId(categoryId, page));
        }

        [HttpPost]
        [Route("add-Market")]
        public async Task<ActionResult> AddMarket([FromForm] Market Market)
        {
            if (Market == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Market);

            return Ok(Market);
        }


        [HttpPost]
        [Route("search-Market")]
        public async Task<ActionResult> SearchMarket([FromForm] string textSearch,[FromForm] int type)
        {

            return Ok(await _repository.SearchMarket(textSearch,type));
        }

        [HttpGet]
        [Route("get-Market-details")]
        public async Task<ActionResult> DetailsMarket([FromQuery] int MarketId)
        {

            return Ok(await _repository.DetailsMarket(MarketId));
        }

        [HttpPost]
        [Route("update-Market")]
        public async Task<ActionResult> UpdateMarket([FromForm] UpdateMarketDto Market, [FromForm] int id)
        {

            return Ok(await _repository.UpdateMarket(Market, id));
        }


        [HttpPost]
        [Route("update-Market-status")]
        public async Task<ActionResult> UpdateMarketStatus([FromForm] int status, [FromForm] int id)
        {

            return Ok(await _repository.UpdateMarketStatus(status, id));
        }



        // [Authorize(Roles = "Market")]


    }
}