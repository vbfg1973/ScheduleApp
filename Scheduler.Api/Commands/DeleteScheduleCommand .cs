using MediatR;

namespace Scheduler.Api.Commands
{
    public class DeleteScheduleCommand : IRequest
    {
        public int Id { get; }

        public DeleteScheduleCommand(int id)
        {
            Id = id;
        }
    }
}