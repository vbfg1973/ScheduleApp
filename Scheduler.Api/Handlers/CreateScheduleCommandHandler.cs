using MediatR;
using Scheduler.Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, ScheduleViewModel>
    {
        private IScheduleRepository _scheduleRepository;
        private IMapper _mapper;

        public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
        }

        public Task<ScheduleViewModel> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            _scheduleRepository.Add(request.Schedule);
            _scheduleRepository.Commit();

            return Task.FromResult(_mapper.Map<Schedule, ScheduleViewModel>(request.Schedule));
        }
    }
}