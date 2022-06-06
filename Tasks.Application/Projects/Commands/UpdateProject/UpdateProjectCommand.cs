using System;
using MediatR;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Projects.Commands.UpdateProject
{
    /// <summary>
    /// Project update command
    /// </summary>
    public class UpdateProjectCommand: IRequest
    {
        /// <summary>
        /// Project ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Project Name
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
        /// Current status of project
        /// </summary>
        public ProjectStatusEnum CurrentStatus { get; set; }
    }
}
