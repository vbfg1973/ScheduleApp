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
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;

        public ScheduleDeleteCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<Unit> Handle(ScheduleDeleteCommand request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(request.Id);

            if (schedule == null)
            {
                throw new KeyNotFoundException();
            }

            try
            {
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