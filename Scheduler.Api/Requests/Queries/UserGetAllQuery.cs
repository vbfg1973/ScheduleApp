using System.Collections.Generic;
using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class UserGetAllQuery : IRequest<IEnumerable<UserViewModel>>
    {
        
    }
}