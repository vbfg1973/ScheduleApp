using System;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Handlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserViewModel>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(request.Id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            return Task.FromResult(_mapper.Map<User, UserViewModel>(user));
        }
    }
}