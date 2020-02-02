using MediatR;
using Scheduler.Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Name = request.UserDto.Name,
                Avatar = request.UserDto.Avatar,
                Profession = request.UserDto.Profession
            };

            _userRepository.Add(user);
            _userRepository.Commit();

            return Task.FromResult(user);
        }
    }
}