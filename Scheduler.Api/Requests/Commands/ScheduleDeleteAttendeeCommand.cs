using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleDeleteAttendeeCommand : IRequest
    {
        public int UserId { get; }
        public int ScheduleId { get; }

        public ScheduleDeleteAttendeeCommand(int scheduleId, int userId)
        {
            ScheduleId = scheduleId;
            UserId = userId;
        }
    }
}