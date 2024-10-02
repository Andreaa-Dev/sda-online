using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ecommerce.src.DTO.ProductDTO;

namespace ecommerce.src.DTO
{
    public class OrderDetailDTO
    {

        public class OrderDetailCreateDto
        {
            public Guid ProductId { get; set; }
            public int Quantity { get; set; }
        }

        public class OrderDetailReadDto
        {
            public Guid Id { get; set; }
            public int Quantity { get; set; }
            public ProductReadDto Product { get; set; }
        }

    }
}