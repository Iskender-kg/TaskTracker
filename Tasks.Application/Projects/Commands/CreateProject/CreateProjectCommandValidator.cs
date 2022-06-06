using System;
using FluentValidation;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.Projects.Commands.CreateProject
{
    public class CreateProjectCommandValidator: AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(createProjectCommand =>
                createProjectCommand.ProjectName).NotEmpty().MaximumLength(165);
            RuleFor(createProjectCommand =>
                createProjectCommand.CurrentStatus).IsInEnum();
            RuleFor(createProjectCommand =>
                createProjectCommand.StartDate).NotNull();
            RuleFor(createProjectCommand =>
                createProjectCommand.CompletionDate).NotNull();
        }
    }
}
