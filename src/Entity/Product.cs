using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
