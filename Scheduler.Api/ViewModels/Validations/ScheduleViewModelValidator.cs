﻿using FluentValidation;
using System;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.ViewModels.Validations
{
    public class ScheduleViewModelValidator : AbstractValidator<ScheduleViewModel>
    {
        public ScheduleViewModelValidator()
        {
            RuleFor(s => s.TimeEnd).Must((start, end) =>
            {
                return DateTimeIsGreater(start.TimeStart, end);
            }).WithMessage("Schedule's End time must be greater than Start time");
        }

        private bool DateTimeIsGreater(DateTime start, DateTime end)
        {
            return end > start;
        }
    }
}