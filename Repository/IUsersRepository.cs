using EffortTracker.Models;

namespace EffortTracker.Repository
{
    public interface IUsersRepository
    {

        Task<IEnumerable<Users>> GetAllUsersAsync();
        Task<Users> GetUserByIdAsync(int associate_id);
        Task AddUserAsync(Users user);
        Task UpdateUserAsync(Users user);
        Task DeleteUserAsync(int associate_id);

    }
}
