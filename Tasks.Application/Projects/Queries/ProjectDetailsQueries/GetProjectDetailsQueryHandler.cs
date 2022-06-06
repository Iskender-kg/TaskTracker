using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using TaskTracker.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Domain;
using TaskTracker.Application.Projects.Queries.GetProjectList;
using AutoMapper.QueryableExtensions;

namespace TaskTracker.Application.Projects.Queries.ProjectDetailsQueries
{
    class GetProjectDetailsQueryHandler: IRequestHandler<GetProjectDetailsQuery, ProjectDetailsVm>
    {
        private readonly ITaskTrackerDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProjectDetailsQueryHandler(ITaskTrackerDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ProjectDetailsVm> Handle(GetProjectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Projects
                .Include(x => x.ProjectTasks)
                .ProjectTo<ProjectDetailsVm>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(project =>
                project.Id == request.Id, cancellationToken);

            if (entity == null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Project), request.Id);
            }

            return (entity);
        }
    }
}
