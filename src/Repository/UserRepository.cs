using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.src.Database;
using ecommerce.src.Entity;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.src.Repository
{
    public class UserRepository
    {
        protected DbSet<User> _user;
        protected DatabaseContext _databaseContext;

        public UserRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _user = databaseContext.Set<User>();
        }

        public async Task<User> CreateOneAsync(User newUser)
        {
            await _user.AddAsync(newUser);
            await _databaseContext.SaveChangesAsync();
            return newUser;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _user.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _user.ToListAsync();
        }
    }
}