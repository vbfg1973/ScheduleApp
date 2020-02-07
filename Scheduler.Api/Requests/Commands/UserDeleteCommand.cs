using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class UserDeleteCommand : IRequest
    {
        public UserDeleteCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}