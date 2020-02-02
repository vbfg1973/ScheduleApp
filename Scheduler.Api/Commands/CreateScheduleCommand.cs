using MediatR;
using Scheduler.Api.Dto;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class CreateScheduleCommand : IRequest<Schedule>
    { 
        public ScheduleDto ScheduleDto { get; }

        public CreateScheduleCommand(ScheduleDto scheduleDto)
        {
            ScheduleDto = scheduleDto;
        }
    }
}