using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using Scheduler.Api.Commands;
using Scheduler.Api.Dto;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ILogger<ScheduleController> _logger;
        private readonly IMediator _mediator;

        public ScheduleController(IScheduleRepository scheduleRepository, IMediator mediator, ILogger<ScheduleController> logger)
        {
            _mediator = mediator;
            _scheduleRepository = scheduleRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Schedule>> Create(ScheduleDto scheduleDto)
        {
            try
            {
                var schedule = await _mediator.Send(new CreateScheduleCommand(scheduleDto));

                return schedule;
            }

            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Schedule>> Update(int id, ScheduleDto scheduleDto)
        {
            try
            {
                var schedule = await _mediator.Send(new UpdateScheduleCommand(id, scheduleDto));
                return schedule;
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
                await _mediator.Send(new DeleteScheduleCommand(id));
            }

            catch (ArgumentNullException)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetSchedule(int id)
        {
            try
            {
                var schedule = await _mediator.Send(new GetScheduleQuery(id));
                return schedule;
            }

            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Schedule>> GetAll()
        {
            var schedules = await _mediator.Send(new GetSchedulesQuery());

            return schedules.ToArray();
        }
    }
}