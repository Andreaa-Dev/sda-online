using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Database;
using ecommerce.src.Entity;
using ecommerce.src.Utils;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.src.Repository
{
    public class OrderRepository
    {
        protected readonly DbSet<Order> _orders;
        protected readonly DatabaseContext _databaseContext;
        protected readonly CartRepository _cartRepo;
        protected readonly ProductRepository _productRepo;

        public OrderRepository(DatabaseContext databaseContext, CartRepository cartRepo, ProductRepository productRepo)
        {
            _databaseContext = databaseContext;
            _orders = _databaseContext.Set<Order>();
            _cartRepo = cartRepo;
            _productRepo = productRepo;
        }

        public async Task<Order?> CreateOneAsync(Order createObject)
        {
            await _orders.AddAsync(createObject);
            await _databaseContext.SaveChangesAsync();

            var orderWithDetails = await _orders
                .Include(o => o.OrderDetails)
                //.ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.Id == createObject.Id);

            return orderWithDetails;
        }

        public async Task<List<Order>> GetOrdersByIdAsync(Guid userId)
        {
            return await _orders
                .Include(o => o.OrderDetails)
                //.ThenInclude(od => od.Product)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        // Checkout logic: Convert cart => order
        public async Task<Order> PayForCart(Guid userId)
        {
            // Fetch the cart for the user
            var cart = await _cartRepo.GetCartByUserId(userId);
            if (cart == null || cart.IsPaid)
            {
                throw CustomException.InvalidOperation("Cart not available or already paid.");
            }

            // Create the order from the cart
            var order = new Order
            {
                UserId = userId,
                TotalAmount = 0,  // Initial total amount, to be calculated below
                OrderDetails = cart.Items.Select(i => new OrderDetail
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    Price = i.Price,
                    SubTotal = i.Price * i.Quantity // Calculate sub-total for this item
                }).ToList()
            };

            // Calculate the total amount for the order (sum of all item sub-totals)
            order.TotalAmount = order.OrderDetails.Sum(i => i.SubTotal);

            // Save the order to the database
            await _orders.AddAsync(order);
            await _databaseContext.SaveChangesAsync(); // Save the new order

            // Reduce product stock for each item in the cart
            foreach (var item in cart.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product != null)
                {
                    product.StockQuantity -= item.Quantity;
                    await _productRepo.UpdateOneAsync(product); // Update the product stock
                }
            }

            // Mark the cart as paid
            cart.IsPaid = true;
            await _cartRepo.UpdateAsync(cart); // Save the updated cart

            return order;
        }


    }
}