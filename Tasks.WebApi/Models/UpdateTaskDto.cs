using AutoMapper;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Application.ProjectTasks.Commands.CreateTask;
using TaskTracker.Application.ProjectTasks.Commands.UpdateTask;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.WebApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public TaskPriorityEnum Priority { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(taskCommand => taskCommand.Priority,
                    opt => opt.MapFrom(taskDto => (TaskPriorityEnum)taskDto.Priority))
                .ForMember(taskCommand => taskCommand.TaskStatus,
                    opt => opt.MapFrom(taskDto => (TaskStatusEnum)taskDto.TaskStatus));
        }
    }
}