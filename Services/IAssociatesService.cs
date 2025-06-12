using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services.Interfaces
{
    public interface IAssociatesService
    {
        Task<IEnumerable<Associates>> GetAllAsync();
        Task<Associates> GetByIdAsync(int id);
        Task AddAsync(Associates associate);
        Task UpdateAsync(Associates associate);
        Task DeleteAsync(int id);
    }
}
