using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scheduler.Api.Commands;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Handle(UpdateUserCommand update, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(x => x.Id == update.Id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.Name = update.UserDto.Name;
            user.Avatar = update.UserDto.Avatar;
            user.Profession = update.UserDto.Profession;

            _userRepository.Update(user);
            _userRepository.Commit();

            return Task.FromResult(user);
        }
    }
}