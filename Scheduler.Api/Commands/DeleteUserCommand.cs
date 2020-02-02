using MediatR;

namespace Scheduler.Api.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}