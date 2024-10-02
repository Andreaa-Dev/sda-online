using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using ecommerce.src.Database;
using ecommerce.src.Entity;
using ecommerce.src.Utils;

namespace ecommerce.src.Repository
{
    public class CategoryRepository
    {

        protected DbSet<Category> _category;
        protected DatabaseContext _databaseContext;

        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _category = databaseContext.Set<Category>();
        }

        public async Task<Category> CreateOneAsync(Category newCategory)
        {
            await _category.AddAsync(newCategory);
            await _databaseContext.SaveChangesAsync();
            return newCategory;
        }

        // add pagination
        public async Task<List<Category>> GetAllAsync(PaginationOptions paginationOptions)
        {
            // Where (p => p.Price)
            // Where (p => p.createdAt)
            // OrderBy
            var result = _category.Where(c => c.Name.ToLower().Contains(paginationOptions.Search.ToLower()));
            return await result.Skip(paginationOptions.Offset).Take(paginationOptions.Limit).ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _category.FindAsync(id);
        }


        public async Task<bool> DeleteOneAsync(Category category)
        {
            _category.Remove(category);
            await _databaseContext.SaveChangesAsync();
            return true;
        }


        // way 2
        // public async Task<bool> DeleteOneAsync(Guid id)
        // {
        //     find category by id
        //     _category.Remove(category);
        //     await _databaseContext.SaveChangesAsync();
        //     return true;
        // }

        public async Task<bool> UpdateOneAsync(Category updateCategory)
        {
            _category.Update(updateCategory);
            await _databaseContext.SaveChangesAsync();
            return true;
            // return updateCategory;
        }
    }
}