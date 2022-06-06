using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.Application.ProjectTasks.Queries.GetTaskList
{
    public class GetTaskListQueryHandler: IRequestHandler<GetTaskListQuery, TaskListVm>
    {
        private readonly ITaskTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetTaskListQueryHandler(ITaskTrackerDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<TaskListVm> Handle(GetTaskListQuery request,
            CancellationToken cancellationToken)
        {
            var taskQuery = await _dbContext.Tasks
                .Where(task => task.ProjectId == request.ProjectId)
                .ProjectTo<TaskLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new TaskListVm { Tasks = taskQuery };
        }
    }
}
