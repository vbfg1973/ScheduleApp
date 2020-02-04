using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scheduler.Api.Requests.Commands;
using Scheduler.Api.Requests.Queries;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IMediator mediator, ILogger<UserController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "UserCreate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> UserCreate(UserViewModel inputUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userViewModel = await _mediator.Send(new UserCreateCommand(inputUserViewModel));
                return new CreatedAtActionResult(nameof(UserGetIndividual),
                    "User",
                    new { id = userViewModel.Id },
                    userViewModel);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}", Name = "UserUpdate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserUpdate(int id, UserViewModel inputUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var userViewModel = await _mediator.Send(new UserUpdateCommand(id, inputUserViewModel));
                return Ok(userViewModel);
            }

            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}", Name = "UserDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserDelete(int id)
        {
            try
            {
                var userViewModel = await _mediator.Send(new UserDeleteCommand(id));
                return NoContent();
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet(Name = "UserGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserGetAll()
        {
            try
            {
                var users = await _mediator.Send(new UserGetAllQuery());
                return Ok(users);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "UserGetIndividual")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserGetIndividual(int id)
        {
            try
            {
                var userViewModel = await _mediator.Send(new UserGetIndividualQuery(id));
                return Ok(userViewModel);
            }

            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}/schedules", Name = "UserGetSchedules")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserGetSchedules(int id)
        {
            try
            {
                var scheduleViewModels = await _mediator.Send(new UserGetScheduleQuery(id));
                return Ok(scheduleViewModels);
            }

            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}