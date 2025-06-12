using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Repositories
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync();
        Task<Tasks> GetTaskByIdAsync(int id);
        Task<Tasks> AddTaskAsync(Tasks task);
        Task<Tasks> UpdateTaskAsync(Tasks task);
        Task<bool> DeleteTaskAsync(int id);
    }
}
