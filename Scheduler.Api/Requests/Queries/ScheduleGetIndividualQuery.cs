using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class ScheduleGetIndividualQuery : IRequest<ScheduleViewModel>
    {
        public ScheduleGetIndividualQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}