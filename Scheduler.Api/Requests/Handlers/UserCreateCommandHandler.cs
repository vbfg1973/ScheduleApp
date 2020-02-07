using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Commands;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Handlers
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, UserViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserCreateCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserViewModel> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = request.UserViewModel.Name,
                Avatar = request.UserViewModel.Avatar,
                Profession = request.UserViewModel.Profession
            };

            try
            {
                _userRepository.Add(user);
                _userRepository.Commit();

                var userViewModel = _mapper.Map<User, UserViewModel>(user);
                return Task.FromResult(userViewModel);
            }

            catch (Exception e)
            {
                throw new Exception("Can't create user", e);
            }
        }
    }
}