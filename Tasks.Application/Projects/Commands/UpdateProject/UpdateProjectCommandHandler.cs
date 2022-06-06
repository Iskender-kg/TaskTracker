using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using TaskTracker.Application.Interfaces;
using MediatR;
using TaskTracker.Domain;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.ProjectTasks.Commands.UpdateTask;
using Microsoft.EntityFrameworkCore;
namespace TaskTracker.Application.Projects.Commands.UpdateProject
{

    /// <summary>
    /// Project update command handler
    /// </summary>
    public class UpdateProjectCommandHandler: IRequestHandler<UpdateProjectCommand>
    {
        /// <summary>
        /// DataBase context
        /// </summary>
        private readonly ITaskTrackerDbContext _dbcontext;

        /// <summary>
        /// Constructor
        /// </summary>
        public UpdateProjectCommandHandler(ITaskTrackerDbContext dbContext) => _dbcontext = dbContext;

        /// <summary>
        /// Update command handle method
        /// </summary>
        public async Task<Unit> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Projects.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(ProjectTask), request.Id);

            entity.ProjectName = request.ProjectName;
            entity.StartDate = request.StartDate;
            entity.CompletionDate = request.CompletionDate;
            entity.CurrentStatus = entity.CurrentStatus; 

            await _dbcontext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
