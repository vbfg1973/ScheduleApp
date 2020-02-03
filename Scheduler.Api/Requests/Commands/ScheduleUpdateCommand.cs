using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Scheduler.Api.ViewModels;

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
