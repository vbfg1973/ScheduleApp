using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Model.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Requests.Handlers
{
    public class UserGetIndividualQueryHandler : IRequestHandler<UserGetIndividualQuery, UserViewModel>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserGetIndividualQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserViewModel> Handle(UserGetIndividualQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(request.Id);

            if (user != null)
            {
                return Task.FromResult(_mapper.Map<User, UserViewModel>(user));
            }

            throw new KeyNotFoundException($"User {request.Id} not found");
        }
    }
}