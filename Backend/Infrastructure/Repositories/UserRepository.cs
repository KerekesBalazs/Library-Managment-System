using Backend.Application.Interfaces.Repositories;
using Backend.Domain.Entities;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    class UserRepository(DataContext _context) : IUserRepository
    {
        public async Task<User> AddUserAsync(User user)
        {
            var createdUser = await _context.Users.AddAsync(user);
            return createdUser.Entity;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var affected = await _context.Users
                .Where(u => u.Id == userId)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public User UpdateUser(User user)
        {
            _context.Users.Update(user);
            return user;
        }
    }
}
