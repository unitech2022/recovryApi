using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DiscoveryZoneApi.Serveries.AlertsServices;
using DiscoveryZoneApi.Dtos;
using DiscoveryZoneApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace DiscoveryZoneApi.Controllers
{



// *** add in subscribe
/// **   Code 

// markets 
//** LogoImage



    [ApiController]
    [Route("alerts")]
    public class AlertsController : ControllerBase
    {
        private readonly IAlertsServices _repository;
        private IMapper _mapper;
        public AlertsController(IAlertsServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-Alert")]
        public async Task<ActionResult> AddAlert([FromForm] Alert Alert)
        {
            if (Alert == null)
            {
                return NotFound();
            }

            await _repository.AddAsync(Alert);

            return Ok(Alert);
        }


        [HttpGet]
        [Route("get-Alerts")]
        public async Task<ActionResult> GetAlerts([FromQuery] int page)
        {

            return Ok(await _repository.GetItems(page));
        }

        [HttpPost]
        [Route("view-Alert")]
        public async Task<ActionResult> ViewAlert([FromForm] int alertId, [FromForm] string userId)
        {
            return Ok(await _repository.ViewedAlert(alertId));
        }
        
          [HttpPost]
        [Route("send-Alert")]
        public async Task<ActionResult> SendAlert([FromForm] Alert alert, [FromForm] string topic)
        {
            return Ok(await _repository.SendNotification(alert,topic));
        }

        [HttpPut]
        [Route("update-Alert")]
        public async Task<ActionResult> UpdateAlert([FromForm] UpdateAlertDto UpdateAlert, [FromForm] int id)

        {
            Alert Alert = await _repository.GitById(id);
            if (Alert == null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateAlert, Alert);

            _repository.UpdateObject(Alert);
            _repository.SaveChanges();

            return Ok(Alert);
        }

        [HttpPost]
        [Route("delete-Alert")]
        public async Task<ActionResult> DeleteAlert([FromForm] int AlertId)
        {
            Alert Alert = await _repository.DeleteAsync(AlertId);

            if (Alert == null)
            {

                return NotFound();
            }



            return Ok(Alert);
        }

    }
}