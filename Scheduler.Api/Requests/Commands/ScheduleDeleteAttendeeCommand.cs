using MediatR;

namespace Scheduler.Api.Requests.Commands
{
    public class ScheduleDeleteAttendeeCommand : IRequest
    {
        public ScheduleDeleteAttendeeCommand(int scheduleId, int userId)
        {
            ScheduleId = scheduleId;
            UserId = userId;
        }

        public int UserId { get; }
        public int ScheduleId { get; }
    }
}