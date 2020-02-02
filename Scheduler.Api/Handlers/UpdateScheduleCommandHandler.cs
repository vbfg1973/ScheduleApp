using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Scheduler.Api.Commands;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Handlers
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, Schedule>
    {
        private IScheduleRepository _scheduleRepository;

        public UpdateScheduleCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<Schedule> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = _scheduleRepository.GetSingle(request.Id);

            if (schedule == null)
            {
                throw new ArgumentNullException();
            }

            schedule.Title = request.ScheduleDto.Title;
            schedule.Description = request.ScheduleDto.Description;
            schedule.TimeStart = request.ScheduleDto.TimeStart;
            schedule.TimeEnd = request.ScheduleDto.TimeEnd;
            schedule.Location = request.ScheduleDto.Location;
            schedule.Type = request.ScheduleDto.Type;
            schedule.Status = request.ScheduleDto.Status;
            schedule.DateCreated = request.ScheduleDto.DateCreated;
            schedule.DateUpdated = request.ScheduleDto.DateUpdated;
            schedule.CreatorId = request.ScheduleDto.CreatorId;

            _scheduleRepository.Update(schedule);
            _scheduleRepository.Commit();

            return Task.FromResult(schedule);
        }
    }
}