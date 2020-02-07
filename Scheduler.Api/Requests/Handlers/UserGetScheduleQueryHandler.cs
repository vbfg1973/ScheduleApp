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
    public class UserGetScheduleQueryHandler : IRequestHandler<UserGetScheduleQuery, IEnumerable<ScheduleViewModel>>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public UserGetScheduleQueryHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<IEnumerable<ScheduleViewModel>> Handle(UserGetScheduleQuery request,
            CancellationToken cancellationToken)
        {
            var results = _scheduleRepository.FindBy(s => s.CreatorId == request.Id);

            return Task.FromResult(_mapper.Map<IEnumerable<Schedule>, IEnumerable<ScheduleViewModel>>(results));
        }
    }
}