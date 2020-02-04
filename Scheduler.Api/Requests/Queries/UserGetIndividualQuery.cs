using MediatR;
using Scheduler.Model.ViewModels;

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