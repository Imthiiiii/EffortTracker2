using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public interface ITasksService
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task<Tasks> CreateTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
