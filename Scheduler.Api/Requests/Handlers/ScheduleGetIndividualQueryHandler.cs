using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleGetIndividualQueryHandler : IRequestHandler<ScheduleGetIndividualQuery, ScheduleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleGetIndividualQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<ScheduleViewModel> Handle(ScheduleGetIndividualQuery request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(s => s.Id == request.Id, s => s.Creator, s => s.Attendees);

            if (schedule != null) return Task.FromResult(_mapper.Map<Schedule, ScheduleViewModel>(schedule));

            throw new KeyNotFoundException($"Schedule {request.Id} not found");
        }
    }
}