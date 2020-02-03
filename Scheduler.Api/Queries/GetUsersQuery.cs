using System.Collections;
using System.Collections.Generic;
using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Queries
{
    public class GetUsersQuery : IRequest<IEnumerable<UserViewModel>>
    {
        
    }
}