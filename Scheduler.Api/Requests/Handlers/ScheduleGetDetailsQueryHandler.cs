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
    public class ScheduleGetDetailsQueryHandler : IRequestHandler<ScheduleGetDetailsQuery, ScheduleDetailsViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;
        private readonly IUserRepository _userRepository;

        public ScheduleGetDetailsQueryHandler(IScheduleRepository scheduleRepository, IUserRepository userRepository,
            IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<ScheduleDetailsViewModel> Handle(ScheduleGetDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(s => s.Id == request.Id, s => s.Creator, s => s.Attendees);

            if (schedule != null)
            {
                var scheduleDetailsViewModel = _mapper.Map<Schedule, ScheduleDetailsViewModel>(schedule);

                foreach (var attendee in schedule.Attendees)
                {
                    var user = _userRepository.GetSingle(attendee.UserId);
                    var userViewModel = _mapper.Map<User, UserViewModel>(user);
                    scheduleDetailsViewModel.Attendees.Add(userViewModel);
                }

                return Task.FromResult(scheduleDetailsViewModel);
            }

            throw new KeyNotFoundException($"Schedule {request.Id} not found");
        }
    }
}