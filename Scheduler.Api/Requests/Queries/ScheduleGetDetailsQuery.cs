using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class ScheduleGetDetailsQuery : IRequest<ScheduleDetailsViewModel>
    {
        public int Id { get; }

        public ScheduleGetDetailsQuery(int id)
        {
            Id = id;
        }
    }
}