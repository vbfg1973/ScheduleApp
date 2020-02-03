using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Scheduler.Data.Abstract;

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
    }
}