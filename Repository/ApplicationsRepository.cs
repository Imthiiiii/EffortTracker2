using EffortTracker.Data;
using EffortTracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Repositories
{
    public class ApplicationsRepository : IApplicationsRepository
    {
        private readonly Context _context;

        public ApplicationsRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Applications>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Applications> GetByIdAsync(int id)
        {
            return await _context.Applications.FindAsync(id);
        }

        public async Task<Applications> AddAsync(Applications application)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Applications ON");
                _context.Applications.Add(application);
                await _context.SaveChangesAsync();
                await _context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Applications OFF");

                await transaction.CommitAsync();
                return application;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }


        public async Task<Applications> UpdateAsync(Applications application)
        {
            _context.Applications.Update(application);
            await _context.SaveChangesAsync();
            return application;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var app = await _context.Applications.FindAsync(id);
            if (app == null) return false;

            _context.Applications.Remove(app);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
