using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Interfaces;
using MediatR;
using TaskTracker.Domain;

namespace TaskTracker.Application.ProjectTasks.Commands.CreateTask
{
    /// <summary>
    /// Handler of the create task command
    /// </summary>
    class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, int>
    {
        private readonly ITaskTrackerDbContext _dbcontext;
        public CreateTaskCommandHandler(ITaskTrackerDbContext dbContext) => _dbcontext = dbContext ;
        public async Task<int> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var projectTask = new ProjectTask
            {
                ProjectId = request.ProjectId,
                TaskName = request.TaskName,
                TaskDescription = request.TaskDescription,
                Priority = request.Priority,
                TaskStatus = request.TaskStatus
            };

            await _dbcontext.Tasks.AddAsync(projectTask, cancellationToken);
            await _dbcontext.SaveChangesAsync(cancellationToken);
            return projectTask.Id;
        }
    }
}
