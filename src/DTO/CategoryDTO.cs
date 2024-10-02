using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.DTO
{
    public class CategoryDTO
    {
        // create category
        public class CategoryCreateDto
        {
            public string Name { get; set; }

        }

        // read data = get data
        public class CategoryReadDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }

        // update
        public class CategoryUpdateDto
        {
            public string Name { get; set; }

        }







    }
}