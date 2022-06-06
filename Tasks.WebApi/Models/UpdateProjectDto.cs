using AutoMapper;
using System;
using TaskTracker.Application.Common.Mappings;
using TaskTracker.Application.Projects.Commands.CreateProject;
using TaskTracker.Application.Projects.Commands.UpdateProject;
using TaskTracker.Domain;
using TaskTracker.Domain.Enums;

namespace TaskTracker.WebApi.Models
{
    public class UpdateProjectDto: IMapWith<UpdateProjectCommand>
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public ProjectStatusEnum CurrentStatus { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateProjectDto, UpdateProjectCommand>()
                .ForMember(projectCommand => projectCommand.CurrentStatus,
                    opt => opt.MapFrom(projectDto => (ProjectStatusEnum)projectDto.CurrentStatus));
        }
    }
}
