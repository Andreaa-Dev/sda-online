using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    public class Category
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }


        [MaxLength(50), MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only letters are allowed")]
        public string Des { get; set; }

        [Range(1, 100)]
        public int Price { get; set; }

    }
}

// validation attributes
// [Required]
// [StringLength(100, MinimumLength= 2)]
// asytu
// string 
// [MaxLength(50)]