using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain;

namespace TaskTracker.Application.Projects.Commands.DeleteProject
{
    /// <summary>
    /// Project delete command handler
    /// </summary>
    public class DeleteProjectCommandHandler: IRequestHandler<DeleteProjectCommand>
    {
        /// <summary>
        /// DataBase context
        /// </summary>
        private readonly ITaskTrackerDbContext _dbcontext;

        /// <summary>
        /// Constructor
        /// </summary>
        public DeleteProjectCommandHandler(ITaskTrackerDbContext dbContext) => _dbcontext = dbContext;

        /// <summary>
        /// Delete command handle method
        /// </summary>
        public async Task<Unit> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbcontext.Projects
                .FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }
            _dbcontext.Projects.Remove(entity);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
