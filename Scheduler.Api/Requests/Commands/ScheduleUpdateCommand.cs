using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleUpdateCommand : IRequest<ScheduleViewModel>
    {
        public int Id { get; }
        public ScheduleViewModel ScheduleViewModel { get; }

        public ScheduleUpdateCommand(int id, ScheduleViewModel scheduleViewModel)
        {
            Id = id;
            ScheduleViewModel = scheduleViewModel;
        }
    }
}
