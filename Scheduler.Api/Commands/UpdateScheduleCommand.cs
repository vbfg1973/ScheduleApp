using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class UpdateScheduleCommand : IRequest<Schedule>
    {
        public int Id { get; }
        public ScheduleViewModel ScheduleDto { get; }

        public UpdateScheduleCommand(int id, ScheduleViewModel scheduleDto)
        {
            Id = id;
            ScheduleDto = scheduleDto;
        }
    }
}