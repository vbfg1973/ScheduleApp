using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Model.ViewModels;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Requests.Handlers
{
    public class UserGetAllQueryHandler : IRequestHandler<UserGetAllQuery, IEnumerable<UserViewModel>>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

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