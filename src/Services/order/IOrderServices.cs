using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ecommerce.src.DTO.OrderDTO;

namespace ecommerce.src.Services.order
{
    public interface IOrderServices
    {
        Task<OrderReadDto> CreateOneAsync(Guid userId, OrderCreateDto createDto);
        Task<List<OrderReadDto>> GetOrdersByIdAsync(Guid userId);

    }
}