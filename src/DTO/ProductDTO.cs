using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Entity;

namespace ecommerce.src.DTO
{
    public class ProductDTO
    {
        public class ProductReadDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Category Category { get; set; }
            // public Guid CategoryId { get; set; }
        }

        public class ProductCreateDto
        {
            public string Name { get; set; }
            public Guid CategoryId { get; set; }

        }
        public class ProductUpdateDto
        {
            public string? Name { get; set; }
        }
    }
}