using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class CreateScheduleCommand : IRequest<ScheduleViewModel>
    { 
        public Schedule Schedule { get; }

        public CreateScheduleCommand(Schedule schedule)
        {
            Schedule = schedule;
        }
    }
}