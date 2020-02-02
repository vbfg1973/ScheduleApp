using MediatR;
using Scheduler.Api.Dto;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class CreateUserCommand : IRequest<User>
    { 
        public UserDto UserDto { get; }

        public CreateUserCommand(UserDto userDto)
        {
            UserDto = userDto;
        }
    }
}