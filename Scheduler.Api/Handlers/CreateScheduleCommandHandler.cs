using MediatR;
using Scheduler.Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, Schedule>
    {
        private IScheduleRepository _scheduleRepository;

        public CreateScheduleCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<Schedule> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule()
            {
                Title = request.ScheduleDto.Title,
                Description = request.ScheduleDto.Description,
                TimeStart = request.ScheduleDto.TimeStart,
                TimeEnd = request.ScheduleDto.TimeEnd,
                Location = request.ScheduleDto.Location,
                Type = request.ScheduleDto.Type,

                Status = request.ScheduleDto.Status,
                DateCreated = request.ScheduleDto.DateCreated,
                DateUpdated = request.ScheduleDto.DateUpdated,
                CreatorId = request.ScheduleDto.CreatorId
            };

            _scheduleRepository.Add(schedule);
            _scheduleRepository.Commit();

            return Task.FromResult(schedule);
        }
    }
}