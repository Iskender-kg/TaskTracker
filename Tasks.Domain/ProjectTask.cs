using System;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Domain
{
    /// <summary>
    /// Task entity
    /// </summary>
    public class ProjectTask
    {
        /// <summary>
        /// Primary key in DB
        /// </summary>
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        /// <summary>
        /// Current status of task
        /// </summary>
        public TaskStatusEnum TaskStatus { get; set; }
        /// <summary>
        /// Foreign key for Project entity
        /// </summary>
        public int ProjectId { get; set; }
        /// <summary>
        /// Navigation property
        /// </summary>
        public Project Project { get; set; }
    }
}
