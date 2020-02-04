using MediatR;
using Scheduler.Model.ViewModels;

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