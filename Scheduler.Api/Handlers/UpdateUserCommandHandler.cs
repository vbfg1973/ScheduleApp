using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Commands;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public Task<UserViewModel> Handle(UpdateUserCommand update, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(update.Id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            user.Name = update.UserDto.Name;
            user.Avatar = update.UserDto.Avatar;
            user.Profession = update.UserDto.Profession;
            _userRepository.Update(user);
            _userRepository.Commit();

            return Task.FromResult(_mapper.Map<User, UserViewModel>(user));
        }
    }
}