using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Commands;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Requests.Handlers
{
    public class UserDeleteCommandHandler : IRequestHandler<UserDeleteCommand>
    {
        private IUserRepository _userRepository;
        private IAttendeeRepository _attendeeRepository;
        private IMapper _mapper;

        public UserDeleteCommandHandler(IUserRepository userRepository, IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _attendeeRepository = attendeeRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(UserDeleteCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(request.Id);

            if (user == null)
            {
                throw new KeyNotFoundException($"User {request.Id} not found");
            }

            try
            {
                _attendeeRepository.DeleteWhere(a => a.UserId == request.Id);

                _userRepository.Delete(user);
                _userRepository.Commit();
            }

            catch (Exception e)
            {
                throw new Exception($"Cannot delete user {request.Id}", e);
            }

            return Unit.Task;
        }
    }
}