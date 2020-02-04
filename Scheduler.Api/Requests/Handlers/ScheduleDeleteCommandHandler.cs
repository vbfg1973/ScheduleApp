using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Commands;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleDeleteCommandHandler : IRequestHandler<ScheduleDeleteCommand>
    {
        private IAttendeeRepository _attendeeRepository;
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;

        public ScheduleDeleteCommandHandler(IScheduleRepository scheduleRepository, IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _attendeeRepository = attendeeRepository;
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(ScheduleDeleteCommand request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(request.Id);

            if (schedule == null)
            {
                throw new KeyNotFoundException($"Schedule {request.Id} not found");
            }

            try
            {
                _attendeeRepository.DeleteWhere(a => a.ScheduleId == request.Id);
                _scheduleRepository.Delete(schedule);
                _scheduleRepository.Commit();
            }

            catch (Exception e)
            {
                throw new Exception($"Cannot delete schedule {request.Id}", e);
            }

            return Unit.Task;
        }
    }
}