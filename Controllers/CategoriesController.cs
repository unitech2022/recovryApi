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
using DiscoveryZoneApi.Serveries.CategoriesServices;

namespace DiscoveryZoneApi.Controllers
{

    [Route("category")]
    [ApiController]
    public class CategoriesController : Controller
    {

        private readonly ICategoriesService _repository;
        private IMapper _mapper;
        public CategoriesController(ICategoriesService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }



        [HttpPost]
        [Route("add-category")]
        public async Task<ActionResult> AddCategory([FromForm] Category category)
        {
            if (category == null)
            {
                return NotFound();
            }

            await _repository.AddCategory(category);

            return Ok(category);
        }


        [HttpGet]
        [Route("get-categories")]
        public async Task<ActionResult> GetCategories()
        {

            return Ok(await _repository.GetAllCategories());
        }

        [HttpGet]
        [Route("get-categories-byFieldid")]
        public async Task<ActionResult> GetCategoriesByFieldId([FromQuery] int fieldId)
        {

            return Ok(await _repository.GetCategoriesByFieldId(fieldId));
        }

        [HttpPut]
        [Route("update-category")]
        public async Task<ActionResult> UpdateCategory([FromForm] UpdateCategoryDto UpdateCategory, [FromForm] int id)

        {
            Category category = await _repository.GitCategoryById(id);
            if (category == null)
            {
                return NotFound();
            }
            _mapper.Map(UpdateCategory, category);

            _repository.UpdateCategory(category);
            _repository.SaveChanges();

            return Ok(category);
        }

        [HttpPost]
        [Route("delete-category")]
        public async Task<ActionResult> DeleteCategory([FromForm] int categoryId)
        {
            Category category = await _repository.DeleteCategory(categoryId);

            if (category == null)
            {

                return NotFound();
            }



            return Ok(category);
        }

    }
}