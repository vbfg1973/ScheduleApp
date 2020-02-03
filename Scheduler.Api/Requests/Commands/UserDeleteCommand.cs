using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class UserDeleteCommand : IRequest
    {
        public int Id { get; }

        public UserDeleteCommand(int id)
        {
            Id = id;
        }
    }
}