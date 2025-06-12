using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int associate_id);
        Task AddUserAsync(Users user);
        Task UpdateUserAsync(Users user);
        Task DeleteUserAsync(int associate_id);
    }
}
