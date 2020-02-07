using System.Collections.Generic;
using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class UserGetAllQuery : IRequest<IEnumerable<UserViewModel>>
    {
    }
}