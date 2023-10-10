using SaleOnIce.Models;

namespace SaleOnIce.Services
{
    public interface IUserServices
    {
        Task<List<User>> GetUsersAsync();

        Task<User?> GetUserByIdAsync(int id);

        Task<User> AddUserAsync(User user);

        Task<User?> PutUserAsync(User user, int id);

        Task DeleteUserAsync(int id);
    }
}