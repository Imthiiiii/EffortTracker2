using EffortTracker.Models;
using EffortTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _taskRepository;

        public TasksService(ITasksRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public Task<IEnumerable<Tasks>> GetAllTasksAsync() => _taskRepository.GetAllTasksAsync();

        public Task<Tasks> GetTaskByIdAsync(int id) => _taskRepository.GetTaskByIdAsync(id);

        public Task<Tasks> CreateTaskAsync(Tasks task) => _taskRepository.AddTaskAsync(task);

        public Task<Tasks> UpdateTaskAsync(Tasks task) => _taskRepository.UpdateTaskAsync(task);

        public Task<bool> DeleteTaskAsync(int id) => _taskRepository.DeleteTaskAsync(id);
    }
}
