using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Commands
{
    public class UserUpdateCommand : IRequest<UserViewModel>
    {
        public UserUpdateCommand(int id, UserViewModel userViewModel)
        {
            Id = id;
            UserViewModel = userViewModel;
        }

        public int Id { get; }
        public UserViewModel UserViewModel { get; }
    }
}