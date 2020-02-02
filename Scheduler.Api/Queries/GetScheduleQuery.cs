using MediatR;
using Scheduler.Model;

namespace Scheduler.Api.Queries
{
    public class GetScheduleQuery : IRequest<Schedule>
    {
        public int Id { get; }

        public GetScheduleQuery(int id)
        {
            Id = id;
        }
    }
}