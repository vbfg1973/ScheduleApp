using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Commands
{
    public class UserCreateCommand : IRequest<UserViewModel>
    {
        public UserCreateCommand(UserViewModel userViewModel)
        {
            UserViewModel = userViewModel;
        }

        public UserViewModel UserViewModel { get; }
    }
}