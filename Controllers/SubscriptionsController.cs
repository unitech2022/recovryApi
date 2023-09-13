using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using DiscoveryZoneApi.Models;

using DiscoveryZoneApi.Serveries.SubscriptionsService;


namespace DiscoveryZoneApi.Controllers
{
    [ApiController]
    [Route("subscription")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsService _repository;
        private IMapper _mapper;
        public SubscriptionsController(ISubscriptionsService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }






        [HttpPost]
        [Route("delete-Subscription")]
        public async Task<ActionResult> DeleteSubscription([FromForm] int SubscriptionId)
        {




            return Ok(await _repository.DeleteAsync(SubscriptionId));
        }



        [HttpGet]
        [Route("get-Subscriptions")]
        public async Task<ActionResult> GetSubscriptions([FromQuery] int page)
        {




            return Ok(await _repository.GetItems(page));
        }

        [HttpGet]
        [Route("get-Subscriptions-byCardId")]
        public async Task<ActionResult> GetSubscriptions([FromQuery] int page, [FromQuery] int cardId)
        {




            return Ok(await _repository.GetSubscriptionsByCardId(page, cardId));
        }


        [HttpPost]
        [Route("add-Subscription")]
        public async Task<ActionResult> AddSubscription([FromForm] Subscription Subscription)
        {
            if (Subscription == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Subscription);

            return Ok(Subscription);
        }


        [HttpPost]
        [Route("search-Subscription")]
        public async Task<ActionResult> SearchSubscription([FromForm] string textSearch)
        {

            return Ok(await _repository.SearchSubscription(textSearch));
        }

        [HttpGet]
        [Route("get-Subscription-details")]
        public async Task<ActionResult> DetailsSubscription([FromQuery] int SubscriptionId)
        {

            return Ok(await _repository.DetailsSubscription(SubscriptionId));
        }



        [HttpPost]
        [Route("update-Subscription")]
        public async Task<ActionResult> UpdateSubscription([FromForm] Subscription Subscription)
        {

            return Ok(await _repository.UpdateSubscription(Subscription));
        }



        // [Authorize(Roles = "Subscription")]


    }
}