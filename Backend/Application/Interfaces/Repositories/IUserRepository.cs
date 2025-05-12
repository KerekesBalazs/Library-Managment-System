using Backend.Domain.Entities;

namespace Backend.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByIdAsync(int id);

        public Task<List<User>> GetUsersAsync();

        public Task<User> AddUserAsync(User user);

        public User UpdateUser(User user);

        public Task<bool> DeleteUserAsync(int userId);
    }
}
