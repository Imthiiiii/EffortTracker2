using EffortTracker.Data;
using EffortTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace EffortTracker.Repositories
{
    public class TimesheetsRepository : ITimesheetsRepository
    {
        private readonly Context _context;

        public TimesheetsRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Timesheets>> GetAllAsync()
        {
            return await _context.Timesheets.ToListAsync();
        }

        public async Task<Timesheets> GetByIdAsync(int id)
        {
            return await _context.Timesheets.FindAsync(id);
        }

        public async Task<Timesheets> AddAsync(Timesheets timesheet)
        {
            var associateExists = await _context.Associates.AnyAsync(a => a.associate_id == timesheet.associate_id);
            var applicationExists = await _context.Applications.AnyAsync(a => a.application_id == timesheet.application_id);
            var taskExists = await _context.Tasks.AnyAsync(t => t.task_id == timesheet.task_id);

            if (!associateExists || !applicationExists || !taskExists)
            {
                throw new ArgumentException("Invalid foreign key reference.");
            }

            timesheet.status = "Pending";

            _context.Timesheets.Add(timesheet);
            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<Timesheets> UpdateAsync(Timesheets timesheet)
        {
            _context.Timesheets.Update(timesheet);
            await _context.SaveChangesAsync();
            return timesheet;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var timesheet = await _context.Timesheets.FindAsync(id);
            if (timesheet == null) return false;

            _context.Timesheets.Remove(timesheet);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
