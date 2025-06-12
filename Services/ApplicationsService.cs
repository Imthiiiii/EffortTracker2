using EffortTracker.Models;
using EffortTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly IApplicationsRepository _repository;

        public ApplicationsService(IApplicationsRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Applications>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Applications> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

        public Task<Applications> AddAsync(Applications application) => _repository.AddAsync(application);

        public Task<Applications> UpdateAsync(Applications application) => _repository.UpdateAsync(application);

        public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
    }
}
