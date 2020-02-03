using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class ScheduleGetIndividualQuery : IRequest<ScheduleViewModel>
    {
        public int Id { get; }

        public ScheduleGetIndividualQuery(int id)
        {
            Id = id;
        }
    }
}