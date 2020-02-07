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
    public class ScheduleController : ControllerBase
    {
        private readonly ILogger<ScheduleController> _logger;
        private readonly IMediator _mediator;

        public ScheduleController(IMediator mediator, ILogger<ScheduleController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost(Name = "ScheduleCreate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> ScheduleCreate(ScheduleViewModel scheduleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var newScheduleViewModel = await _mediator.Send(new ScheduleCreateCommand(scheduleViewModel));
                return Ok(newScheduleViewModel);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}", Name = "ScheduleUpdate")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ScheduleUpdate(int id, ScheduleViewModel scheduleViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var newScheduleViewModel = await _mediator.Send(new ScheduleUpdateCommand(id, scheduleViewModel));
                return Ok(newScheduleViewModel);
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

        [HttpDelete("{id}", Name = "ScheduleDelete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ScheduleDelete(int id)
        {
            try
            {
                var scheduleViewModel = await _mediator.Send(new ScheduleDeleteCommand(id));
                return NoContent();
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{scheduleId}/attendee/{userId}", Name = "ScheduleDeleteAttendee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ScheduleDeleteAttendee(int scheduleId, int userId)
        {
            try
            {
                var scheduleViewModel = await _mediator.Send(new ScheduleDeleteAttendeeCommand(scheduleId, userId));
                return NoContent();
            }

            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet(Name = "ScheduleGetAll")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ScheduleGetAll()
        {
            try
            {
                var schedules = await _mediator.Send(new ScheduleGetAllQuery());
                return Ok(schedules);
            }

            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}", Name = "ScheduleGetIndividual")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ScheduleGetIndividual(int id)
        {
            try
            {
                var scheduleViewModel = await _mediator.Send(new ScheduleGetIndividualQuery(id));
                return Ok(scheduleViewModel);
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

        [HttpGet("{id}/details", Name = "ScheduleGetDetails")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ScheduleGetDetails(int id)
        {
            try
            {
                var scheduleDetailsViewModel = await _mediator.Send(new ScheduleGetDetailsQuery(id));
                return Ok(scheduleDetailsViewModel);
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