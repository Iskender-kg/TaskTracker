using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Interfaces;
using MediatR;
using TaskTracker.Domain;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.ProjectTasks.Commands.UpdateTask;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Application.ProjectTasks.Commands.CreateTask
{
    /// <summary>
    /// Task update command handler
    /// </summary>
    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand>
    {
        private readonly ITaskTrackerDbContext _dbcontext;
        public UpdateTaskCommandHandler(ITaskTrackerDbContext dbContext) => _dbcontext = dbContext;
        public async Task<Unit> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Tasks.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(ProjectTask), request.Id);

            entity.TaskName = request.TaskName;
            entity.TaskDescription = request.TaskDescription;
            entity.Priority = request.Priority;
            entity.TaskStatus = request.TaskStatus;

            await _dbcontext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}