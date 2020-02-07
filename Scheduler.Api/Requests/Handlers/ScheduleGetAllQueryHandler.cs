using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleGetAllQueryHandler : IRequestHandler<ScheduleGetAllQuery, IEnumerable<ScheduleViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleGetAllQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ScheduleViewModel>> Handle(ScheduleGetAllQuery request,
            CancellationToken cancellationToken)
        {
            var schedules = _scheduleRepository.AllIncluding(s => s.Creator, s => s.Attendees);

            return Task.FromResult(_mapper.Map<IEnumerable<ScheduleViewModel>>(schedules));
        }
    }
}