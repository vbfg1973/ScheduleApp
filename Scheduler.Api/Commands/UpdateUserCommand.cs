using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Commands
{
    public class UpdateUserCommand : IRequest<UserViewModel>
    {
        public int Id { get; }
        public User UserDto { get; }

        public UpdateUserCommand(int id, User userDto)
        {
            Id = id;
            UserDto = userDto;
        }
    }
}