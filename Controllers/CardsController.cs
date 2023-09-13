using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DiscoveryZoneApi.Dtos;
using DiscoveryZoneApi.Models;
using DiscoveryZoneApi.Serveries.CardsServices;

namespace DiscoveryZoneApi.Controllers
{

    [Route("card")]
    [ApiController]
    public class CardsController : Controller
    {

        private readonly ICardsService _repository;
        private IMapper _mapper;
        public CardsController(ICardsService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-Card")]
        public async Task<ActionResult> AddCard([FromForm] Card Card)
        {
            if (Card == null)
            {
                return NotFound();
            }

            await _repository.AddCard(Card);

            return Ok(Card);
        }


        [HttpGet]
        [Route("get-Cards")]
        public async Task<ActionResult> GetCards()
        {

            return Ok(await _repository.GetAllCards());
        }




        [HttpPut]
        [Route("update-Card")]
        public async Task<ActionResult> UpdateCard([FromForm] UpdateCardDto UpdateCard, [FromForm] int id)

        {
            Card Card = await _repository.GitCardById(id);
            if (Card == null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateCard, Card);

            _repository.UpdateCard(Card);
            _repository.SaveChanges();

            return Ok(Card);
        }

        [HttpPost]
        [Route("delete-Card")]
        public async Task<ActionResult> DeleteCard([FromForm] int CardId)
        {
            Card Card = await _repository.DeleteCard(CardId);

            if (Card == null)
            {

                return NotFound();
            }



            return Ok(Card);
        }

    }
}