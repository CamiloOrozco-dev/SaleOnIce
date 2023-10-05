using SaleOnIce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
