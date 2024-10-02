using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        // 2 steps 
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        // size
        // public Guid Size { get; set; }
        // public Size Size { get; set; }
    }
}


// ERD not Entity
// ERD: categoryId in Product table
// Entity: categoryId and category