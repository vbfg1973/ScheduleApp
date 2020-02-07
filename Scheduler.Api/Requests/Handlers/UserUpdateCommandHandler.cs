﻿using System;
using System.Collections.Generic;
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
    public class UserUpdateCommandHandler : IRequestHandler<UserUpdateCommand, UserViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserUpdateCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<UserViewModel> Handle(UserUpdateCommand request, CancellationToken cancellationToken)
        {
            var u = _userRepository.GetSingle(request.Id);

            if (u != null)
            {
                u.Name = request.UserViewModel.Name;
                u.Avatar = request.UserViewModel.Avatar;
                u.Profession = request.UserViewModel.Profession;

                try
                {
                    _userRepository.Update(u);
                    _userRepository.Commit();

                    return Task.FromResult(_mapper.Map<User, UserViewModel>(u));
                }

                catch (Exception e)
                {
                    throw new Exception($"Can't update user {request.Id}", e);
                }
            }

            throw new KeyNotFoundException($"User {request.Id} not found");
        }
    }
}