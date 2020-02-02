using MediatR;
using Scheduler.Model;

namespace Scheduler.Api.Queries
{
    public class GetUserQuery : IRequest<User>
    {
        public int Id { get; }

        public GetUserQuery(int id)
        {
            Id = id;
        }
    }
}