using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Interfaces;
using MediatR;
using TaskTracker.Domain;

namespace TaskTracker.Application.Projects.Commands.CreateProject
{
    /// <summary>
    /// Handler of the create project command
    /// </summary>
    class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int>
    {
        /// <summary>
        /// DataBase context
        /// </summary>
        private readonly ITaskTrackerDbContext _dbcontext;

        /// <summary>
        /// Constructor
        /// </summary>
        public CreateProjectCommandHandler(ITaskTrackerDbContext dbContext) => _dbcontext = dbContext;

        /// <summary>
        /// Create command handle method
        /// </summary>
        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                ProjectName = request.ProjectName,
                StartDate = request.StartDate,
                CompletionDate = request.CompletionDate,
                CurrentStatus = request.CurrentStatus
            };

            await _dbcontext.Projects.AddAsync(project, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return project.Id;
        }
    }
}
