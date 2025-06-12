using AutoMapper;
using EffortTracker.Models;
using EffortTracker.DTOs;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EffortTracker.Profiles
{
    public class TimesheetProfile : Profile
    {
        public TimesheetProfile()
        {
            CreateMap<Timesheets, TimesheetReadDto>();
            CreateMap<TimesheetCreateDto, Timesheets>();
        }
    }
}
