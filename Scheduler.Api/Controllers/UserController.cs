﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Scheduler.Api.Commands;
using Scheduler.Api.ViewModels;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IUserRepository userRepository, IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Create(User user)
        {
            try
            {
                var userViewModel = await _mediator.Send(new CreateUserCommand(user));

                return userViewModel;
            }

            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            try
            {
                var userViewModel = await _mediator.Send(new UpdateUserCommand(id, user));
                return NoContent();
            }

            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteUserCommand(id));
                return NoContent();
            }

            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            try
            {
                var user = await _mediator.Send(new GetUserQuery(id));
                return user;
            }

            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _mediator.Send(new GetUsersQuery());

            return users.ToArray();
        }
    }
}