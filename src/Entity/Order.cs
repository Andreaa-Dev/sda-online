using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.src.Entity
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        // list has 3 item
        // product + quantity
        public List<OrderDetail> OrderDetails { get; set; }

        // total


    }
}