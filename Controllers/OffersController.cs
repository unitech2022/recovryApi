using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoveryZoneApi.Serveries.OffersServices;
using DiscoveryZoneApi.Dtos;
using DiscoveryZoneApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DiscoveryZoneApi.Controllers
{
    [ApiController]
    [Route("offers")]
    public class OffersController : ControllerBase
    {
        private readonly IOffersServices _repository;
        private IMapper _mapper;
        public OffersController(IOffersServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-Offer")]
        public async Task<ActionResult> AddOffer([FromForm] Offer Offer)
        {
            if (Offer == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Offer);

            return Ok(Offer);
        }


        [HttpGet]
        [Route("get-Offers")]
        public async Task<ActionResult> GetOffers([FromQuery] int page)
        {

            return Ok(await _repository.GetItems(page));
        }

        [HttpPost]
        [Route("update-status-Offer")]
        public async Task<ActionResult> UpdateOfferStatus([FromForm] int status, [FromForm] int id)

        {


            return Ok(await _repository.UpdateOfferStatus(status, id));
        }

        [HttpPut]
        [Route("update-Offer")]
        public async Task<ActionResult> UpdateOffer([FromForm] string DescAr, [FromForm] string image, [FromForm] int order, [FromForm] int id)

        {


            return Ok(await _repository.UpdateOffer(image, DescAr, order, id));
        }

        [HttpPost]
        [Route("delete-Offer")]
        public async Task<ActionResult> DeleteOffer([FromForm] int OfferId)
        {
            Offer Offer = await _repository.DeleteAsync(OfferId);

            if (Offer == null)
            {

                return NotFound();
            }



            return Ok(Offer);
        }

    }
}