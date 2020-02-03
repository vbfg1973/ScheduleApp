using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Queries
{
    public class GetScheduleQuery : IRequest<ScheduleViewModel>
    {
        public int Id { get; }

        public GetScheduleQuery(int id)
        {
            Id = id;
        }
    }
}