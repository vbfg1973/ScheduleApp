using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Queries;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleGetIndividualQueryHandler : IRequestHandler<ScheduleGetIndividualQuery, ScheduleViewModel>
    {
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;

        public ScheduleGetIndividualQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<ScheduleViewModel> Handle(ScheduleGetIndividualQuery request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(s => s.Id == request.Id, s => s.Creator, s => s.Attendees);

            if (schedule != null)
            {
                return Task.FromResult(_mapper.Map<Schedule, ScheduleViewModel>(schedule));
            }

            throw new KeyNotFoundException();
        }
    }
}