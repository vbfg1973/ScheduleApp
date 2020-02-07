﻿using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Scheduler.Api.Requests.Commands;
using Scheduler.Data.Abstract;
using Scheduler.Model;
using Scheduler.Model.ViewModels;

namespace Scheduler.Api.Requests.Handlers
{
    public class ScheduleCreateCommandHandler : IRequestHandler<ScheduleCreateCommand, ScheduleViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleCreateCommandHandler(IScheduleRepository scheduleRepository, IMapper mapper)
        {
            _scheduleRepository = scheduleRepository;
            _mapper = mapper;
        }

        public Task<ScheduleViewModel> Handle(ScheduleCreateCommand request, CancellationToken cancellationToken)
        {
            var schedule = _mapper.Map<ScheduleViewModel, Schedule>(request.ScheduleViewModel);
            schedule.DateCreated = DateTime.UtcNow;

            try
            {
                _scheduleRepository.Add(schedule);
                _scheduleRepository.Commit();

                foreach (var userId in request.ScheduleViewModel.Attendees)
                    schedule.Attendees.Add(new Attendee {UserId = userId});

                _scheduleRepository.Commit();

                return Task.FromResult(_mapper.Map<Schedule, ScheduleViewModel>(schedule));
            }

            catch (Exception e)
            {
                throw new Exception("Unable to create schedule", e);
            }
        }
    }
}