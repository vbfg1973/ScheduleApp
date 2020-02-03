using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class CreateUserCommand : IRequest<UserViewModel>
    { 
        public User UserDto { get; }

        public CreateUserCommand(User userDto)
        {
            UserDto = userDto;
        }
    }
}