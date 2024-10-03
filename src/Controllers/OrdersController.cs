using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ecommerce.src.Services.order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static ecommerce.src.DTO.OrderDTO;

namespace ecommerce.src.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {

        protected readonly IOrderServices _orderService;
        public OrdersController(IOrderServices service)
        {
            _orderService = service;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> CreateOnAsync([FromBody] OrderCreateDto orderCreateDto)
        {
            var authenticateClaims = HttpContext.User;

            var userId = authenticateClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            var userGuid = new Guid(userId);

            return await _orderService.CreateOneAsync(userGuid, orderCreateDto);

        }

        [HttpGet("user/{userId}")]
        [Authorize]

        public async Task<ActionResult<List<OrderReadDto>>> GetOrdersByUserId([FromRoute] Guid userId)
        {
            var orders = await _orderService.GetOrdersByIdAsync(userId);
            return Ok(orders);
        }

    }
}