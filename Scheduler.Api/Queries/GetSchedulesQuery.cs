using System.Collections;
using System.Collections.Generic;
using MediatR;
using Scheduler.Model;

namespace Scheduler.Api.Queries
{
    public class GetSchedulesQuery : IRequest<IEnumerable<Schedule>>
    {
        
    }
}