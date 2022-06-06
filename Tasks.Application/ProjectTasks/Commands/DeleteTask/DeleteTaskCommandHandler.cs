using MediatR;
using System.Threading.Tasks;
using System.Threading;
using TaskTracker.Application.Interfaces;
using TaskTracker.Application.Common.Exceptions;

namespace TaskTracker.Application.ProjectTasks.Commands.DeleteTask
{
    /// <summary>
    /// Task delete command handler
    /// </summary>
    class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand>
    {
        private readonly ITaskTrackerDbContext _dbcontext;
        public DeleteTaskCommandHandler(ITaskTrackerDbContext dbContext) => _dbcontext = dbContext; 
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Tasks
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if(entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Task), request.Id);
            }
            _dbcontext.Tasks.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
