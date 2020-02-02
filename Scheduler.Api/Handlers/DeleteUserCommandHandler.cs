using System;
using System.Runtime.InteropServices.ComTypes;
using MediatR;
using Scheduler.Api.Commands;
using System.Threading;
using System.Threading.Tasks;
using Scheduler.Data.Abstract;

namespace Scheduler.Api.Handlers
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.GetSingle(request.Id);

            if (user == null)
            {
                throw new ArgumentNullException();
            }

            _userRepository.Delete(user);
            _userRepository.Commit();

            return Unit.Task;
        }
    }
}