using System.Collections.Generic;
using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class UserGetScheduleQuery : IRequest<IEnumerable<ScheduleViewModel>>
    {
        public UserGetScheduleQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}