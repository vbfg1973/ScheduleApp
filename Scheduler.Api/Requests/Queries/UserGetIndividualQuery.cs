using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class UserGetIndividualQuery : IRequest<UserViewModel>
    {
        public int Id { get; }

        public UserGetIndividualQuery(int id)
        {
            Id = id;
        }
    }
}