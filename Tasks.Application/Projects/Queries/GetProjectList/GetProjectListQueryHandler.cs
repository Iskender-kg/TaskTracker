using AutoMapper;
using AutoMapper.QueryableExtensions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Interfaces;
namespace TaskTracker.Application.Projects.Queries.GetProjectList
{
    /// <summary>
    /// Query handler for receive project list
    /// </summary>
    public class GetProjectListQueryHandler: IRequestHandler<GetProjectListQuery, ProjectListVm>
    {
        private readonly ITaskTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectListQueryHandler(ITaskTrackerDbContext dbContext,
            IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectListVm> Handle(GetProjectListQuery request,
            CancellationToken cancellationToken)
        {
            var projectsQuery = await _dbContext.Projects
                .Include(x => x.ProjectTasks)
                .ProjectTo<ProjectLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ProjectListVm { Projects = projectsQuery };
        }
    }
}
