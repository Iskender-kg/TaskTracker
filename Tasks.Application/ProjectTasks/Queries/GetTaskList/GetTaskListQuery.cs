using System;
using MediatR;

namespace TaskTracker.Application.ProjectTasks.Queries.GetTaskList
{
    public class GetTaskListQuery: IRequest<TaskListVm>
    {
        public int ProjectId { get; set; }
    }
}
