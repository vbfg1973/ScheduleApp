﻿using System.Collections.Generic;
using MediatR;
using Scheduler.Api.ViewModels;

namespace Scheduler.Api.Requests.Queries
{
    public class UserGetScheduleQuery : IRequest<IEnumerable<ScheduleViewModel>>
    {
        public int Id { get; }

        public UserGetScheduleQuery(int id)
        {
            Id = id;
        }
    }
}