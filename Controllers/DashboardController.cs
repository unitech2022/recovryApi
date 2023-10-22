using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoveryZoneApi.Serveries.DashboardServices;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiscoveryZoneApi.Controllers
{
    [Route("dashboard")]
    public class DashboardController : Controller
    {

        private readonly IDashboardServices _repository;
        private IMapper _mapper;
        public DashboardController(IDashboardServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




        [HttpGet]
        [Route("home")]
        public async Task<ActionResult> GetHomeDashboard([FromQuery] string userId)
        {
            return Ok(await _repository.GetHomeDashboard(userId));
        }

        [HttpPost]
        [Route("get-fields")]
        public async Task<ActionResult> GetFields([FromForm] int page, [FromForm] string textSearch)
        {
            return Ok(await _repository.GetField(page, textSearch));
        }

        [HttpPost]
        [Route("get-alerts")]
        public async Task<ActionResult> GetAlerts([FromForm] int page, [FromForm] string textSearch)
        {
            return Ok(await _repository.GetAlerts(page, textSearch));
        }


        [HttpPost]
        [Route("get-subscriptions")]
        public async Task<ActionResult> GetSubscriptions([FromForm] int page, [FromForm] string textSearch)
        {
            return Ok(await _repository.GetSubscriptions(page, textSearch));
        }

        [HttpGet]
        [Route("get-all-fields")]
        public async Task<ActionResult> GetAllFields()
        {
            return Ok(await _repository.GetFields());
        }

        [HttpGet]
        [Route("get-offers")]
        public async Task<ActionResult> GeOffers()
        {
            return Ok(await _repository.GetOffers());
        }

        [HttpPost]
        [Route("get-categories")]
        public async Task<ActionResult> GetCategories([FromForm] int page, [FromForm] string textSearch)
        {
            return Ok(await _repository.GetCategories(page, textSearch));
        }

        [HttpPost]
        [Route("get-markets")]
        public async Task<ActionResult> GetMarkets([FromForm] int page, [FromForm] string textSearch)
        {
            return Ok(await _repository.GetMarkets(page, textSearch));
        }

        // [Authorize(Roles = "admin")]
        [HttpPost]
        [Route("update-subscription")]
        public async Task<ActionResult> UpdateSubscriptionStatus([FromForm] int subscribeId, [FromForm] int status)
        {
            return Ok(await _repository.UpdateStatusSubscription(subscribeId, status));
        }

        // [Authorize(Roles = "admin")]
        // [HttpPost]
        // [Route("block-user")]
        // public async Task<ActionResult> BlockUser([FromForm] string userId, [FromForm] int status)
        // {
        //     return Ok(await _repository.BlockUser(userId, status));
        // }

        // [Authorize(Roles = "admin")]
        // [HttpPost]
        // [Route("update-wallet")]
        // public async Task<ActionResult> UpdateWalletStatus([FromForm] int walletId, [FromForm] int status)
        // {
        //     return Ok(await _repository.UpdateStatusWallet(walletId, status));
        // }

        // [Authorize(Roles = "admin")]
        // [HttpPost]
        // [Route("get-wallets")]
        // public async Task<ActionResult> GetOrdersWallets([FromForm] int page)
        // {
        //     return Ok(await _repository.GetWallets(page));
        // }


        // [HttpPost]
        // [Route("get-products")]
        // public async Task<ActionResult> GetProducts([FromForm] int page, [FromForm] string textSearch)
        // {
        //     return Ok(await _repository.GetProducts(page, textSearch));
        // }


        // [HttpPost]
        // [Route("get-users")]
        // public async Task<ActionResult> GetUsers([FromForm] int page, [FromForm] string textSearch)
        // {
        //     return Ok(await _repository.GetUsers(page, textSearch));
        // }

        // [HttpPost]
        // [Route("get-orders")]
        // public async Task<ActionResult> GetOrders([FromForm] int page)
        // {
        //     return Ok(await _repository.GetOrders(page));
        // }

        // [Authorize(Roles = "admin")]
        // [HttpPost]
        // [Route("update-product-status")]
        // public async Task<ActionResult> UpdateProductStatus([FromForm] int productId, [FromForm] int status)
        // {
        //     return Ok(await _repository.UpdateStatusProduct(productId, status));
        // }



        // [Authorize(Roles = "admin")]
        // [HttpPost]
        // [Route("payment-provider")]
        // public async Task<ActionResult> payMentProvider([FromForm] string userId, [FromForm] double mony, [FromForm] int type)
        // {
        //     return Ok(await _repository.PaymentProvider(userId, mony, type));
        // }
    }
}