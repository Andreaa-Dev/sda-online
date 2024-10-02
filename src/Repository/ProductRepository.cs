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

        // method
        // create product in database
        public async Task<Product> CreateOneAsync(Product newProduct)
        {
            await _products.AddAsync(newProduct);
            await _databaseContext.SaveChangesAsync();
            return newProduct;
        }

        // get product by id
        public async Task<Product?> GetByIdAsync(Guid id)
        {
            // to see the category detail
            // include => 
            // return await _products.FindAsync(id);
            return await _products.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            // size
            //return await _products.Include(p => p.Category).Include(p => p.Size).FirstOrDefaultAsync(p => p.Id == id);
        }


        // delete 
        public async Task<bool> DeleteOneAsync(Product product)
        {
            _products.Remove(product);
            await _databaseContext.SaveChangesAsync();
            return true;
        }


        // update product
        public async Task<bool> UpdateOneAsync(Product updateProduct)
        {
            _products.Update(updateProduct);
            await _databaseContext.SaveChangesAsync();
            return true;
        }


        // get all products
        public async Task<List<Product>> GetAllAsync()
        {
            return await _products.ToListAsync();
        }



    }
}