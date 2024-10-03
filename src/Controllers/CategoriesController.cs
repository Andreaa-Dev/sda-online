using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Services.category;
using ecommerce.src.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ecommerce.src.DTO.CategoryDTO;


namespace ecommerce.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : ControllerBase
    {

        protected readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService service)
        {
            _categoryService = service;
        }

        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<ActionResult<CategoryReadDto>> CreateOne([FromBody] CategoryCreateDto createDto)
        {
            var categoryCreated = await _categoryService.CreateOneAsync(createDto);
            return Created($"api/v1/categories/{categoryCreated.Id}", categoryCreated);
        }

        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<List<CategoryReadDto>>> GetAll([FromQuery] PaginationOptions paginationOptions)
        {
            var categoryList = await _categoryService.GetAllAsync(paginationOptions);
            return Ok(categoryList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryReadDto>> GetById([FromRoute] Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(category);
        }


    }
}