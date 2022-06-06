using System;
using FluentValidation;
using TaskTracker.Domain.Enums;

namespace TaskTracker.Application.ProjectTasks.Commands.UpdateTask
{
    class UpdateTaskCommandValidator: AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(updateProjectCommand =>
                updateProjectCommand.TaskName).NotEmpty().MaximumLength(165);
            RuleFor(updateProjectCommand =>
                updateProjectCommand.TaskDescription).NotEmpty();
            RuleFor(updateProjectCommand =>
                updateProjectCommand.TaskStatus).NotEmpty();
            RuleFor(updateProjectCommand =>
                updateProjectCommand.Priority).NotEmpty();
        }
    }
}
