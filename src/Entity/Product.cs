using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    // [Table("ProductEc")]
    public class Product
    {
        [Key]
        public Guid Id { get; set; }

        // [Column("ProductName", TypeName = "varchar(100)")]
        public string Name { get; set; }

        // 2 steps 
        [ForeignKey("CategoryId")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        // size
        // public Guid Size { get; set; }
        // public Size Size { get; set; }

        // example
        // 10.40
        //[Column("ProductPrice", TypeName = "decimal(18,2)")]
        //[Range(1,100)]
        // [Range(1, double.MinValue, ErrorMessage = "price ")]
        //[Range(100, double.MaxValue, ErrorMessage = "price ")]

        // public decimal Price { get; set; }
    }
}


// Annotation: Schema attributes
// Relational attribute
// [Table("ProductEc")]
