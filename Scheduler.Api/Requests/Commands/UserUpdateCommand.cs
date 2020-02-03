using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Commands
{
    public class UserUpdateCommand : IRequest<UserViewModel>
    {
        public int Id { get; }
        public UserViewModel UserViewModel { get; }

        public UserUpdateCommand(int id, UserViewModel userViewModel)
        {
            Id = id;
            UserViewModel = userViewModel;
        }
    }
}
