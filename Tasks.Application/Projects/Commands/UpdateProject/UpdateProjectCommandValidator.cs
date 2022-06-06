using System;
using FluentValidation;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Projects.Commands.UpdateProject
{
    class UpdateProjectCommandValidator: AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(updateProjectCommand =>
                updateProjectCommand.ProjectName).NotEmpty().MaximumLength(165);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.CurrentStatus).NotEmpty();
        }
    }
}
