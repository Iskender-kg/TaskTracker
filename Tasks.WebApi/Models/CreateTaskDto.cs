using AutoMapper;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Application.ProjectTasks.Commands.CreateTask;
using TaskTracker.Domain;
using System;
using TaskTracker.Domain.Enums;

namespace TaskTracker.WebApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
        public int ProjectId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Priority,
                    opt => opt.MapFrom(taskDto => (TaskPriorityEnum)taskDto.Priority))
                .ForMember(taskCommand => taskCommand.TaskStatus,
                    opt => opt.MapFrom(taskDto => (TaskStatusEnum)taskDto.TaskStatus));
        }
    }
}