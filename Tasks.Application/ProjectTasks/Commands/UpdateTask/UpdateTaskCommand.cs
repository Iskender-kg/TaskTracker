using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.ProjectTasks.Commands.UpdateTask
{
    /// <summary>
    /// Task update command
    /// </summary>
    public class UpdateTaskCommand : IRequest
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
    }
}
