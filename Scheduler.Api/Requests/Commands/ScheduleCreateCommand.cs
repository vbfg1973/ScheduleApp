using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleCreateCommand : IRequest<ScheduleViewModel>
    {
        public ScheduleViewModel ScheduleViewModel { get; }

        public ScheduleCreateCommand(ScheduleViewModel scheduleViewModel)
        {
            ScheduleViewModel = scheduleViewModel;
        }
    }
}