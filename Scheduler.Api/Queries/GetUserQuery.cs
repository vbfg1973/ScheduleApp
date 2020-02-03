using MediatR;
using Scheduler.Api.ViewModels;
using Scheduler.Model;

namespace Scheduler.Api.Queries
{
    public class GetUserQuery : IRequest<UserViewModel>
    {
        public int Id { get; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}