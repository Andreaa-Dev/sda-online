using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Database;
using ecommerce.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.src.Repository
{
    public class OrderRepository
    {
        protected readonly DbSet<Order> _orders;
        protected readonly DatabaseContext _databaseContext;



        public OrderRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _orders = _databaseContext.Set<Order>();
        }


        // createOneAsync
        public async Task<Order?> CreateOneAsync(Order createObject)
        {
            await _orders.AddAsync(createObject);
            await _databaseContext.SaveChangesAsync();

            // orderReadDto
            // step 1: get order detail in order
            // await _orders.Entry(createObject).Collection(o => o.OrderDetails).LoadAsync();
            // // step 2: get product information from orderDetail

            // foreach (var detail in createObject.OrderDetails)
            // {
            //     await _databaseContext.Entry(detail).Reference(od => od.Product).LoadAsync();
            // }

            // return createObject;


            // use Include
            // order - orderDetail - product
            var orderWithDetails = await _orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .FirstOrDefaultAsync(o => o.Id == createObject.Id);
            return orderWithDetails;

        }

        // get list of order by user Id
        // include 2 

        public async Task<List<Order>> GetOrdersByIdAsync(Guid userId)
        {
            return await _orders
            .Include(o => o.OrderDetails)
            .ThenInclude(od => od.Product)
            .Where(o => o.UserId == userId)
            .ToListAsync();
        }


    }
}