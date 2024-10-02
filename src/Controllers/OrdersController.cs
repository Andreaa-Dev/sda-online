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


        // method
        // create order
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderReadDto>> CreateOnAsync([FromBody] OrderCreateDto orderCreateDto)
        {
            // exact user information by token
            var authenticateClaims = HttpContext.User;

            // get user id by claims
            var userId = authenticateClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            // string => Guid
            var userGuid = new Guid(userId);

            return await _orderService.CreateOneAsync(userGuid, orderCreateDto);

        }

        // get order list of order by userId
        // url: http://localhost:5228/api/v1/orders/user/7593873651
        [HttpGet("user/{userId}")]
        [Authorize]

        public async Task<ActionResult<List<OrderReadDto>>> GetOrdersByUserId([FromRoute] Guid userId)
        {
            var orders = await _orderService.GetOrdersByIdAsync(userId);
            return Ok(orders);
        }






    }
}