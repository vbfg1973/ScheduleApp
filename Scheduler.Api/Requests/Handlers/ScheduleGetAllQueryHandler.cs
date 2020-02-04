using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Model.ViewModels;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleGetAllQueryHandler : IRequestHandler<ScheduleGetAllQuery, IEnumerable<ScheduleViewModel>>
    {
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;

        public ScheduleGetAllQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ScheduleViewModel>> Handle(ScheduleGetAllQuery request, CancellationToken cancellationToken)
        {
            var schedules = _scheduleRepository.AllIncluding(s => s.Creator, s => s.Attendees);

            return Task.FromResult(_mapper.Map<IEnumerable<ScheduleViewModel>>(schedules));
        }
    }
}