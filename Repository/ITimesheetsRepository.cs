using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Repositories
{
    public interface ITimesheetsRepository
    {
        Task<IEnumerable<Timesheets>> GetAllAsync();
        Task<Timesheets> GetByIdAsync(int id);
        Task<Timesheets> AddAsync(Timesheets timesheet);
        Task<Timesheets> UpdateAsync(Timesheets timesheet);
        Task<bool> DeleteAsync(int id);
    }
}
