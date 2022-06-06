using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskTracker.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Domain;

namespace TaskTracker.Application.ProjectTasks.Queries.TaskDetailsQueries
{
    class GetTaskDetailsQueryHandler: IRequestHandler<GetTaskDetailsQuery, TaskDetailsVm>
    {
        private readonly ITaskTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskDetailsQueryHandler(ITaskTrackerDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskDetailsVm> Handle(GetTaskDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks
                .FirstOrDefaultAsync(task =>
                task.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(ProjectTask), request.Id);
            }

            return _mapper.Map<TaskDetailsVm>(entity);
        }
    }
}
