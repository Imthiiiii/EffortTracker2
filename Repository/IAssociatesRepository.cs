using EffortTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace EffortTracker.Repository

{
    public interface IAssociatesRepository
    {

        Task<IEnumerable<Associates>> GetAllAsync();
        Task<Associates> GetByIdAsync(int id);
        Task AddAsync(Associates entity);
        void Update(Associates entity);
        void Delete(Associates entity);
        Task SaveAsync();

    }
}
