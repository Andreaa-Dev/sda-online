using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ecommerce.src.Database;
using ecommerce.src.Entity;

namespace ecommerce.src.Repository
{
    public class ProductRepository
    {
        protected DbSet<Product> _products;
        protected DatabaseContext _databaseContext;

        // DI
        public ProductRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _products = databaseContext.Set<Product>();
        }

        public async Task<Product> CreateOneAsync(Product newProduct)
        {
            await _products.AddAsync(newProduct);
            await _databaseContext.SaveChangesAsync();
            return newProduct;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {

            return await _products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task<bool> DeleteOneAsync(Product product)
        {
            _products.Remove(product);
            await _databaseContext.SaveChangesAsync();
            return true;
        }


        public async Task<bool> UpdateOneAsync(Product updateProduct)
        {
            _products.Update(updateProduct);
            await _databaseContext.SaveChangesAsync();
            return true;
        }


        public async Task<List<Product>> GetAllAsync()
        {
            return await _products.ToListAsync();
        }



    }
}