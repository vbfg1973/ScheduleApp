using System;
using System.Runtime.InteropServices.ComTypes;
using MediatR;
using Scheduler.Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Handlers
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand>
    {
        private IScheduleRepository _scheduleRepository;

        public DeleteScheduleCommandHandler(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public Task<Unit> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var Schedule = _scheduleRepository.GetSingle(request.Id);

            if (Schedule == null)
            {
                throw new ArgumentNullException();
            }

            _scheduleRepository.Delete(Schedule);
            _scheduleRepository.Commit();

            return Unit.Task;
        }
    }
}