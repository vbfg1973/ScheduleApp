using MediatR;
using Scheduler.Model.ViewModels;

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