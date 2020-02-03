using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleDeleteCommand : IRequest
    {
        public int Id { get; }

        public ScheduleDeleteCommand(int id)
        {
            Id = id;
        }
    }
}