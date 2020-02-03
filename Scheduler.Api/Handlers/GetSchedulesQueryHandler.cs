using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class GetSchedulesQueryHandler : IRequestHandler<GetSchedulesQuery, IEnumerable<ScheduleViewModel>>
    {
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;
        public GetSchedulesQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public Task<IEnumerable<ScheduleViewModel>> Handle(GetSchedulesQuery query, CancellationToken cancellationToken)
        {
            var schedules = _scheduleRepository.GetAll();

            return Task.FromResult(_mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(schedules));
        }
    }
}