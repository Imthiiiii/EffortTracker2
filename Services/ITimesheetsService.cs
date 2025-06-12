using EffortTracker.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public interface ITimesheetsService
    {
        Task<IEnumerable<TimesheetReadDto>> GetAllAsync();
        Task<TimesheetReadDto> GetByIdAsync(int id);
        Task<TimesheetReadDto> AddAsync(TimesheetCreateDto dto);
        Task<TimesheetReadDto> UpdateAsync(int id, TimesheetCreateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
