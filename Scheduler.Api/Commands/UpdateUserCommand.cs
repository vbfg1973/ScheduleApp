using MediatR;
using Scheduler.Api.Dto;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class UpdateUserCommand : IRequest<User>
    {
        public int Id { get; }
        public UserDto UserDto { get; }

        public UpdateUserCommand(int id, UserDto userDto)
        {
            Id = id;
            UserDto = userDto;
        }
    }
}