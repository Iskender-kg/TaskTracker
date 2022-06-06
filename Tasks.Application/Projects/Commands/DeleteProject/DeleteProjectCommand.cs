using MediatR;
using System;

namespace TaskTracker.Application.Projects.Commands.DeleteProject
{
    /// <summary>
    /// Project delete command
    /// </summary>
    public class DeleteProjectCommand: IRequest
    {
        /// <summary>
        /// Project ID
        /// </summary>
        public int Id { get; set; }        
    }
}
