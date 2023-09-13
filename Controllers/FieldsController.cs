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
using DiscoveryZoneApi.Serveries.FieldsServices;

namespace DiscoveryZoneApi.Controllers
{

    [Route("field")]
    [ApiController]
    public class FieldsController : Controller
    {

        private readonly IFieldsService _repository;
        private IMapper _mapper;
        public FieldsController(IFieldsService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-Field")]
        public async Task<ActionResult> AddField([FromForm] Field Field)
        {
            if (Field == null)
            {
                return NotFound();
            }

            await _repository.AddField(Field);

            return Ok(Field);
        }


        [HttpGet]
        [Route("get-Fields")]
        public async Task<ActionResult> GetFields()
        {

            return Ok(await _repository.GetAllFields());
        }




        [HttpPut]
        [Route("update-Field")]
        public async Task<ActionResult> UpdateField([FromForm] UpdateFieldDto UpdateField, [FromForm] int id)

        {
            Field Field = await _repository.GitFieldById(id);
            if (Field == null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateField, Field);

            _repository.UpdateField(Field);
            _repository.SaveChanges();

            return Ok(Field);
        }

        [HttpPost]
        [Route("delete-Field")]
        public async Task<ActionResult> DeleteField([FromForm] int FieldId)
        {
            Field Field = await _repository.DeleteField(FieldId);

            if (Field == null)
            {

                return NotFound();
            }

            return Ok(Field);
        }

    }
}