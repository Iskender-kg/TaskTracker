using System;
using MediatR;

namespace TaskTracker.Application.ProjectTasks.Commands.DeleteTask
{
    /// <summary>
    /// Task delete command
    /// </summary>
    public class DeleteTaskCommand: IRequest
    {
        /// <summary>
        /// Task ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project ID
        /// </summary>
        public int ProjectId { get; set; }
    }
}
