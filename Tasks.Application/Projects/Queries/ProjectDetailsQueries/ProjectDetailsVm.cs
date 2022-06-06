using System;
using System.Collections.Generic;
using AutoMapper;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Application.ProjectTasks.Queries.TaskDetailsQueries;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Projects.Queries.ProjectDetailsQueries
{
    public class ProjectDetailsVm: IMapWith<Project>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatusEnum CurrentStatus { get; set; }
        public List<ProjectTask> ProjectTasks { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Project, ProjectDetailsVm>();
        }
    }
}
