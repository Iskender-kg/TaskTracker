using System;
using MediatR;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Projects.Commands.CreateProject
{
    /// <summary>
    /// Project creation command
    /// </summary>
    public class CreateProjectCommand : IRequest<int>
    {
        /// <summary>
        /// Project name
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// Planned start of the project dateTime
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Date when the project will end
        /// </summary>
        public DateTime CompletionDate { get; set; }

        /// <summary>
        /// Current status the project
        /// </summary>
        public ProjectStatusEnum CurrentStatus { get; set; }
    }
}
