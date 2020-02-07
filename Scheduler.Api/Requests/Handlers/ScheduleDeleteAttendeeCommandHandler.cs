using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Commands;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleDeleteAttendeeCommandHandler : IRequestHandler<ScheduleDeleteAttendeeCommand>
    {
        private readonly IAttendeeRepository _attendeeRepository;
        private IMapper _mapper;

        public ScheduleDeleteAttendeeCommandHandler(IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _attendeeRepository = attendeeRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(ScheduleDeleteAttendeeCommand request, CancellationToken cancellationToken)
        {
            if (_attendeeRepository.FindBy(a => a.UserId == request.UserId &&
                                                a.ScheduleId == request.ScheduleId) == null)
                throw new KeyNotFoundException(
                    $"User {request.UserId} is not associated with schedule {request.ScheduleId}");
            _attendeeRepository.DeleteWhere(a => a.UserId == request.UserId && a.ScheduleId == request.ScheduleId);
            _attendeeRepository.Commit();

            return Unit.Task;
        }
    }
}