using SaleOnIce.Models;
using SaleOnIce.Repository;

namespace SaleOnIce.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository) {
        
        _userRepository = userRepository;
        }

        public async Task<User> AddUserAsync(User user)
        {
            
           return await _userRepository.SaveAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            bool userExist = await _userRepository.ExistsAsync(id);
            if (!userExist)
                throw new KeyNotFoundException($"Product with id {id} not found");

        await _userRepository.DeleteAsync(id);
         
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
           var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new KeyNotFoundException($"Product with id {id} not found");
                return user;

        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task<User?> PutUserAsync(User user, int id)
        {
            var userExist= await _userRepository.ExistsAsync(id);
            if(!userExist)
                throw new KeyNotFoundException($"Product with id {id} not found");
            return await _userRepository.UpdateAsync(id, user);
        }
    }
}