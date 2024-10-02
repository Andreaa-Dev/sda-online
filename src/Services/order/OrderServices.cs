using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ecommerce.src.DTO;
using ecommerce.src.Entity;
using ecommerce.src.Repository;
using static ecommerce.src.DTO.OrderDTO;

namespace ecommerce.src.Services.order
{
    public class OrderServices : IOrderServices
    {
        protected readonly OrderRepository _orderRepo;

        protected readonly IMapper _mapper;

        public OrderServices(OrderRepository orderRepo, IMapper mapper)
        {
            _orderRepo = orderRepo;
            _mapper = mapper;
        }


        public async Task<OrderReadDto> CreateOneAsync(Guid userId, OrderCreateDto createDto)
        {
            var order = _mapper.Map<OrderCreateDto, Order>(createDto);
            order.UserId = userId;
            await _orderRepo.CreateOneAsync(order);
            return _mapper.Map<Order, OrderReadDto>(order);
        }


        public async Task<List<OrderReadDto>> GetOrdersByIdAsync(Guid userId)
        {
            var orders = await _orderRepo.GetOrdersByIdAsync(userId);
            var orderList = _mapper.Map<List<Order>, List<OrderReadDto>>(orders);
            return orderList;
        }

    }
}