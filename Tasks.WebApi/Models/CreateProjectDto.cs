using AutoMapper;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Application.ProjectTasks.Commands.CreateTask;
using TaskTracker.Domain;
using System;
using TaskTracker.Domain.Enums;
using TaskTracker.Application.Projects.Commands.CreateProject;

namespace TaskTracker.WebApi.Models
{
    public class CreateProjectDto: IMapWith<CreateProjectCommand>
    {
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatusEnum CurrentStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProjectDto, CreateProjectCommand>()
                .ForMember(projectCommand => projectCommand.CurrentStatus,
                    opt => opt.MapFrom(projectDto => (ProjectStatusEnum)projectDto.CurrentStatus))
                .ForMember(projectCommand => projectCommand.StartDate,
                    opt => opt.MapFrom(projectDto => (DateTime)projectDto.StartDate))
                .ForMember(projectCommand => projectCommand.CompletionDate,
                    opt => opt.MapFrom(projectDto => (DateTime)projectDto.CompletionDate));

        }
    }
}
