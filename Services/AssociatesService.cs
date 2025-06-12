using EffortTracker.Models;
using EffortTracker.Repository;
using EffortTracker.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services.Implementations
{
    public class AssociatesService : IAssociatesService
    {
        private readonly IAssociatesRepository _repository;

        public AssociatesService(IAssociatesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Associates>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Associates> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(Associates associate)
        {
            await _repository.AddAsync(associate);
            await _repository.SaveAsync();
        }

        public async Task UpdateAsync(Associates associate)
        {
            _repository.Update(associate);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var associate = await _repository.GetByIdAsync(id);
            if (associate != null)
            {
                _repository.Delete(associate);
                await _repository.SaveAsync();
            }
        }
    }
}
