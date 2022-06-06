using System.Collections.Generic;

namespace TaskTracker.Application.ProjectTasks.Queries.GetTaskList
{
    public class TaskListVm
    {
        public IList<TaskLookupDto> Tasks { get; set; }
    }
}
