using MediatR;
using System;

namespace TaskTracker.Application.Projects.Queries.ProjectDetailsQueries
{
    public class GetProjectDetailsQuery: IRequest<ProjectDetailsVm>
    {
        public int Id { get; set; }
    }
}
