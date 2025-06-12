using AutoMapper;
using EffortTracker.DTOs;
using EffortTracker.Models;
using EffortTracker.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EffortTracker.Services
{
    public class TimesheetsService : ITimesheetsService
    {
        private readonly ITimesheetsRepository _repository;
        private readonly IMapper _mapper;

        public TimesheetsService(ITimesheetsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TimesheetReadDto>> GetAllAsync()
        {
            var timesheets = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TimesheetReadDto>>(timesheets);
        }

        public async Task<TimesheetReadDto> GetByIdAsync(int id)
        {
            var timesheet = await _repository.GetByIdAsync(id);
            return _mapper.Map<TimesheetReadDto>(timesheet);
        }

        public async Task<TimesheetReadDto> AddAsync(TimesheetCreateDto dto)
        {
            var entity = _mapper.Map<Timesheets>(dto);
            var created = await _repository.AddAsync(entity);
            return _mapper.Map<TimesheetReadDto>(created);
        }

        public async Task<TimesheetReadDto> UpdateAsync(int id, TimesheetCreateDto dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return null;

            existing.date = dto.date;
            existing.associate_id = dto.associate_id;
            existing.application_id = dto.application_id;
            existing.task_id = dto.task_id;
            existing.hours = dto.hours;
            existing.comments = dto.comments;

            var updated = await _repository.UpdateAsync(existing);
            return _mapper.Map<TimesheetReadDto>(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
