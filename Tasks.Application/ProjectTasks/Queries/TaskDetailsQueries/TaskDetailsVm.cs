using System;
using AutoMapper;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.ProjectTasks.Queries.TaskDetailsQueries
{
    public class TaskDetailsVm: IMapWith<ProjectTask>
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProjectTask, TaskDetailsVm>();
        }
    }
}
