using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Commands;
using Scheduler.Api.ViewModels;
using Scheduler.Data.Abstract;
using Scheduler.Model;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleUpdateCommandHandler : IRequestHandler<ScheduleUpdateCommand, ScheduleViewModel>
    {
        private IScheduleRepository _scheduleRepository;
        private IAttendeeRepository _attendeeRepository;
        private IMapper _mapper;

        public ScheduleUpdateCommandHandler(IScheduleRepository scheduleRepository, IAttendeeRepository attendeeRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<ScheduleViewModel> Handle(ScheduleUpdateCommand request, CancellationToken cancellationToken)
        {
            var schedule = request.ScheduleViewModel;
            var scheduleDb = _scheduleRepository.GetSingle(request.Id);

            if (scheduleDb != null)
            {
                scheduleDb.Title = schedule.Title;
                scheduleDb.Location = schedule.Location;
                scheduleDb.Description = schedule.Description;
                scheduleDb.Status = (ScheduleStatus)Enum.Parse(typeof(ScheduleStatus), schedule.Status);
                scheduleDb.Type = (ScheduleType)Enum.Parse(typeof(ScheduleType), schedule.Type);
                scheduleDb.TimeStart = schedule.TimeStart;
                scheduleDb.TimeEnd = schedule.TimeEnd;

                // Remove current attendees
                _attendeeRepository.DeleteWhere(a => a.ScheduleId == request.Id);

                foreach (var userId in schedule.Attendees)
                {
                    scheduleDb.Attendees.Add(new Attendee { ScheduleId = request.Id, UserId = userId });
                }

                try
                {
                    _scheduleRepository.Update(scheduleDb);
                    _scheduleRepository.Commit();

                    return Task.FromResult(_mapper.Map<Schedule, ScheduleViewModel>(scheduleDb));
                }

                catch (Exception e)
                {
                    throw new Exception($"Can't update schedule {request.Id}", e);
                }
            }

            throw new KeyNotFoundException();
        }
    }
}