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


        // public Dictionary<OrderDetail> OrderDetailDic { get; set; }


        // seed data
        // dictionary database 
        // word - meanings
        // q: 
        // json - from internet
        // fe: form 
        // word
        // meaning


        // total


    }
}