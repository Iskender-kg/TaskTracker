using System;
using MediatR;

namespace TaskTracker.Application.Projects.Queries.GetProjectList
{
    /// <summary>
    /// Query to receive project list
    /// </summary>
    public class GetProjectListQuery: IRequest<ProjectListVm>
    {
    }
}
