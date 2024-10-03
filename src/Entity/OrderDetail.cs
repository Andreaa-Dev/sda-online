using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    public class OrderDetail
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }

        // see the product detail
        // public Product Product { get; set; }

        // Sub-total for this item (Price * Quantity)
        public decimal Price { get; set; }  // Price per item
        public decimal SubTotal { get; set; }
    }
}