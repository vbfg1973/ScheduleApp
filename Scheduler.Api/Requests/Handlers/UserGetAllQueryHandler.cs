using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Handlers
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IEnumerable<UserViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserGetAllQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<UserViewModel>> Handle(UserGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();

            return Task.FromResult(_mapper.Map<IEnumerable<UserViewModel>>(users));
        }
    }
}