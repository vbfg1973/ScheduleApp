using System;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Scheduler.Api.Handlers
{
    public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, Schedule>
    {
        private IScheduleRepository _scheduleRepository;
        public GetScheduleQueryHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<Schedule> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(u => u.Id == request.Id);

            if (schedule == null)
            {
                throw new ArgumentNullException();
            }

            return Task.FromResult(schedule);
        }
    }
}