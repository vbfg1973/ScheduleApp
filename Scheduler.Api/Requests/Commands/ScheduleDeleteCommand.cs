using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleDeleteCommand : IRequest
    {
        public ScheduleDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}