using System;
using FluentValidation;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.ProjectTasks.Commands.CreateTask
{
    public class CreateTaskCommandValidator: AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(createProjectCommand =>
                createProjectCommand.TaskName).NotEmpty().MaximumLength(165);
            RuleFor(createProjectCommand =>
                createProjectCommand.TaskStatus).IsInEnum();
            RuleFor(createProjectCommand =>
                createProjectCommand.Priority).IsInEnum();
            RuleFor(createProjectCommand =>
                createProjectCommand.TaskDescription).NotEmpty().MaximumLength(165);
        }
    }
}
