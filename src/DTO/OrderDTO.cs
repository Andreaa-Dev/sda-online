using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ecommerce.src.DTO.OrderDetailDTO;

namespace ecommerce.src.DTO
{
    public class OrderDTO
    {
        public class OrderReadDto
        {
            public Guid Id { get; set; }
            public Guid UserId { get; set; }
            public List<OrderDetailReadDto> OrderDetails { get; set; }

        }


        public class OrderCreateDto
        {
            //public List<OrderDetailReadDto> OrderDetails { get; set; }
            public List<OrderDetailCreateDto> OrderDetails { get; set; }
        }
    }


}