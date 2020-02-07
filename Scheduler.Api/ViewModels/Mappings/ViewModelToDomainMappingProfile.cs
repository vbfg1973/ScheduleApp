using System.Collections.Generic;
using AutoMapper;
using Scheduler.Model;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.ViewModels.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ScheduleViewModel, Schedule>()
                .ForMember(s => s.Creator, map => map.MapFrom(src => default(User)))
                .ForMember(s => s.Attendees, map => map.MapFrom(src => new List<Attendee>()));

            CreateMap<UserViewModel, User>();
        }
    }
}