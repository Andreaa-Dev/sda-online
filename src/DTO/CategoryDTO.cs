using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.DTO
{
    public class CategoryDTO
    {
        public class CategoryCreateDto
        {
            [Required]
            public string Name { get; set; }

        }
        public class CategoryReadDto
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

        }

        public class CategoryUpdateDto
        {
            public string Name { get; set; }
        }







    }
}