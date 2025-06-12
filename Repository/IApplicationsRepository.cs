using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Repositories
{
    public interface IApplicationsRepository
    {
        Task<IEnumerable<Applications>> GetAllAsync();
        Task<Applications> GetByIdAsync(int id);
        Task<Applications> AddAsync(Applications application);
        Task<Applications> UpdateAsync(Applications application);
        Task<bool> DeleteAsync(int id);
    }
}
