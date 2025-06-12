using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public interface IApplicationsService
    {
        Task<IEnumerable<Applications>> GetAllAsync();
        Task<Applications> GetByIdAsync(int id);
        Task<Applications> AddAsync(Applications application);
        Task<Applications> UpdateAsync(Applications application);
        Task<bool> DeleteAsync(int id);
    }
}
