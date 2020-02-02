using System;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Api.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User>
    {
        private IUserRepository _userRepository;
        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(request.Id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            return Task.FromResult(user);
        }
    }
}