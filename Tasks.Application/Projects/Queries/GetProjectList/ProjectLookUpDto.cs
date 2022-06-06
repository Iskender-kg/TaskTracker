using AutoMapper;
using System;
using System.Collections.Generic;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Projects.Queries.GetProjectList
{
    /// <summary>
    /// Entity to receive project 
    /// </summary>
    public class ProjectLookUpDto: IMapWith<Project>
    {
        /// <summary>
        /// Project identificator
        /// </summary>
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatusEnum CurrentStatus { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectLookUpDto>();
        }
    }
}
