using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Database;
using ecommerce.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.src.Repository
{
    public class CartRepository
    {
        protected DbSet<Cart> _cart;
        protected DatabaseContext _databaseContext;
        protected ProductRepository _productRepo;

        public CartRepository(DatabaseContext databaseContext, ProductRepository productRepo)
        {
            _databaseContext = databaseContext;
            _cart = databaseContext.Set<Cart>();
            _productRepo = productRepo;
        }

        public async Task AddItemToCart(Guid userId, Guid productId, int quantity)
        {
            // Fetch the product and check its availability
            var product = await _productRepo.GetByIdAsync(productId);
            if (product == null || product.StockQuantity < quantity)
            {
                throw new InvalidOperationException("Product not available or insufficient stock.");
            }

            // Fetch the user's cart or create a new one
            var cart = await GetCartByUserId(userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _cart.Add(cart);
                await _databaseContext.SaveChangesAsync(); // Save the cart
            }

            // Check if the product is already in the cart
            var cartItem = cart.Items.FirstOrDefault(i => i.ProductId == productId);
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Price = product.Price
                };
                cart.Items.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            // Reduce the product stock quantity
            product.StockQuantity -= quantity;

            // Update the product and save the changes to the cart
            await _productRepo.UpdateOneAsync(product);
            _cart.Update(cart);
            await _databaseContext.SaveChangesAsync(); // Save changes to the database
        }

        public async Task<Cart?> GetCartByUserId(Guid userId)
        {
            return await _cart.Include(c => c.Items).FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task UpdateAsync(Cart cart)
        {
            _cart.Update(cart);
            await _databaseContext.SaveChangesAsync();
        }

    }
}