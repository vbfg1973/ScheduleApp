using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, IEnumerable<Schedule>>
    {
        private IScheduleRepository _scheduleRepository;
        public GetSchedulesQueryHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<IEnumerable<Schedule>> Handle(GetSchedulesQuery query, CancellationToken cancellationToken)
        {
            var schedules = _scheduleRepository.GetAll();

            return Task.FromResult(schedules);
        }
    }
}