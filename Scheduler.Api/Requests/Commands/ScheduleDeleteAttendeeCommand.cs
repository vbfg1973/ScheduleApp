using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleDeleteAttendeeCommand : IRequest
    {
        public int UserId { get; set; }
        public int ScheduleId { get; set; }
    }
}