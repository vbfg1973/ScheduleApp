using MediatR;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class UserGetIndividualQuery : IRequest<UserViewModel>
    {
        public UserGetIndividualQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}