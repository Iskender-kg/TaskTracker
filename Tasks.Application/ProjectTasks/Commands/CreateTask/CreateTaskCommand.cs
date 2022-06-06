using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.ProjectTasks.Commands.CreateTask
{
    /// <summary>
    /// Create task command
    /// </summary>
    public class CreateTaskCommand : IRequest<int>
    {
        /// <summary>
        /// Project ID
        /// </summary>
        public int ProjectId { get; set; }

        /// <summary>
        /// Create task command
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Task description
        /// </summary>
        public string TaskDescription { get; set; }

        /// <summary>
        /// Task priority
        /// </summary>
        public TaskPriorityEnum Priority { get; set; }

        /// <summary>
        /// Task status enum
        /// </summary>
        public TaskStatusEnum TaskStatus { get; set; }
    }
}
