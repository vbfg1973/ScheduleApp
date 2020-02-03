using System;
using MediatR;
using Scheduler.Api.Queries;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Handlers
{
    public class GetScheduleQueryHandler : IRequestHandler<GetScheduleQuery, ScheduleViewModel>
    {
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;
        public GetScheduleQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public Task<ScheduleViewModel> Handle(GetScheduleQuery request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(request.Id);

            if (schedule == null)
            {
                throw new ArgumentNullException();
            }

            return Task.FromResult(_mapper.Map<Schedule, ScheduleViewModel>(schedule));
        }
    }
}