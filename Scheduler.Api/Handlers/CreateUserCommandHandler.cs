using MediatR;
using Scheduler.Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.UserDto.Name,
                Avatar = request.UserDto.Avatar,
                Profession = request.UserDto.Profession
            };

            _userRepository.Add(user);
            _userRepository.Commit();

            return Task.FromResult(_mapper.Map<User, UserViewModel>(user));
        }
    }
}