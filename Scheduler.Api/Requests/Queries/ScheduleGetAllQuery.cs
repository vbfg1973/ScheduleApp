using System.Collections.Generic;
using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class ScheduleGetAllQuery : IRequest<IEnumerable<ScheduleViewModel>>
    {
        
    }
}