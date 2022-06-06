using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTracker.Application.Projects.Queries.GetProjectList
{
    /// <summary>
    /// ViewModel of the project list
    /// </summary>
    public class ProjectListVm
    {
        public IList<ProjectLookUpDto> Projects { get; set; }
    }
}
