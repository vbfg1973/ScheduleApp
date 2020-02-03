using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Commands
{
    public class UserCreateCommand : IRequest<UserViewModel>
    {
        public UserViewModel UserViewModel { get; }

        public UserCreateCommand(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
        }
    }
}