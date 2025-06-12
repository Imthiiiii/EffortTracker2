using EffortTracker.Models;
using EffortTracker.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _usersRepository.GetAllUsersAsync();
        }

        public async Task<Users> GetUserByIdAsync(int associate_id)
        {
            return await _usersRepository.GetUserByIdAsync(associate_id);
        }

        public async Task AddUserAsync(Users user)
        {
            await _usersRepository.AddUserAsync(user);
        }

        public async Task UpdateUserAsync(Users user)
        {
            await _usersRepository.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int associate_id)
        {
            await _usersRepository.DeleteUserAsync(associate_id);
        }
    }
}
