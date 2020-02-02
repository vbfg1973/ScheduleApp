using MediatR;
using Scheduler.Api.Dto;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class UpdateScheduleCommand : IRequest<Schedule>
    {
        public int Id { get; }
        public ScheduleDto ScheduleDto { get; }

        public UpdateScheduleCommand(int id, ScheduleDto scheduleDto)
        {
            Id = id;
            ScheduleDto = scheduleDto;
        }
    }
}