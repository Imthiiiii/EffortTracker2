using EffortTracker.Data;
using EffortTracker.Models;
using EffortTracker.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Repositories.Implementations
{
    public class AssociatesRepository : IAssociatesRepository
    {
        private readonly Context _context;

        public AssociatesRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Associates>> GetAllAsync()
        {
            return await _context.Associates.ToListAsync();
        }

        public async Task<Associates> GetByIdAsync(int id)
        {
            return await _context.Associates.FindAsync(id);
        }

        public async Task AddAsync(Associates entity)
        {
            var connection = _context.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();

                using var transaction = await _context.Database.BeginTransactionAsync();

                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Associates ON");

                await _context.Associates.AddAsync(entity);
                await _context.SaveChangesAsync();

                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Associates OFF");

                await transaction.CommitAsync();
            }
            finally
            {
                await connection.CloseAsync();
            }
        }

        public void Update(Associates entity)
        {
            _context.Associates.Update(entity);
        }

        public void Delete(Associates entity)
        {
            _context.Associates.Remove(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
