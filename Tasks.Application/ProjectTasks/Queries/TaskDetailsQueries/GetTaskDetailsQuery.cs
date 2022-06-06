using System;
using MediatR;

namespace TaskTracker.Application.ProjectTasks.Queries.TaskDetailsQueries
{
    public class GetTaskDetailsQuery: IRequest<TaskDetailsVm>
    {
        public int Id { get; set; }
    }
}
