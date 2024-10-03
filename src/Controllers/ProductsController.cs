using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Services.product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ecommerce.src.DTO.ProductDTO;

namespace ecommerce.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        protected readonly IProductService _productService;

        public ProductsController(IProductService service)
        {
            _productService = service;
        }
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateOneAsync([FromBody] ProductCreateDto createDto)
        {
            var productCreated = await _productService.CreateOneAsync(createDto);
            return Ok(productCreated);
        }


        [HttpGet]
        public async Task<ActionResult<List<ProductReadDto>>> GetAllAsync()
        {
            var productList = await _productService.GetAllAsync();
            return Ok(productList);
        }

        [HttpGet("{id:guid}")]

        public async Task<ActionResult<ProductReadDto>> GetByIdAsync([FromRoute] Guid id)
        {
            var product = await _productService.GetByIdAsync(id);
            return Ok(product);
        }

    }
}