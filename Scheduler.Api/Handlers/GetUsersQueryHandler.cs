using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, IEnumerable<UserViewModel>>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<IEnumerable<UserViewModel>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var users = _userRepository.GetAll();
            return Task.FromResult(_mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users));
        }
    }
}