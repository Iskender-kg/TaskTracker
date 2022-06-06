using System;
using System.Collections.Generic;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Domain
{
    /// <summary>
    /// Project entity
    /// </summary>
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatusEnum CurrentStatus { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
    }
}