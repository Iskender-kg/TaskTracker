using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.ProjectTasks.Commands.CreateTask;
using TaskTracker.Application.ProjectTasks.Commands.DeleteTask;
using TaskTracker.Application.ProjectTasks.Commands.UpdateTask;
using TaskTracker.Application.Projects.Commands.UpdateProject;
using TaskTracker.Application.Projects.Commands.DeleteProject;
using TaskTracker.Application.Projects.Commands.CreateProject;
using TaskTracker.Application.ProjectTasks.Queries.TaskDetailsQueries;
using TaskTracker.Application.Projects.Queries.GetProjectList;
using TaskTracker.Application.ProjectTasks.Queries.GetTaskList;
using TaskTracker.WebApi.Models;
using TaskTracker.Application.Projects.Queries.ProjectDetailsQueries;

namespace TaskTracker.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskTrackerController : BaseController
    {
        private readonly IMapper _mapper;

        public TaskTrackerController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        /// <summary>
        /// Gets all projects with tasks that exist in db
        /// </summary>
        /// <returns></returns>
        [HttpGet("get-all-projects")]
        public async Task<ActionResult<ProjectListVm>> GetAllProjects()
        {
            var query = new GetProjectListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        /// <summary>
        /// Gets all tasks 
        /// </summary>
        [HttpGet("get-all-tasks/{projectId}")]
        public async Task<ActionResult<TaskListVm>> GetAllTasks(int projectId)
        {
            var query = new GetTaskListQuery
            {
                ProjectId = projectId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets project by its id
        /// </summary>
        /// <param name="projectId">Project identificator</param>
        /// <returns></returns>
        [HttpGet("get-project/{projectId}")]
        public async Task<ActionResult> GetProject(int projectId)
        {
            var query = new GetProjectDetailsQuery
            {
                Id = projectId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        /// <summary>
        /// Gets task by its id
        /// </summary>
        /// <param name="taskId">Task identificator</param>
        /// <returns></returns>
        [HttpGet("get-task/{taskId}")]
        public async Task<ActionResult> GetTask(int taskId)
        {
            var query = new GetTaskDetailsQuery
            {
                Id = taskId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        /// <summary>
        /// Creates project
        /// </summary>
        [HttpPost("create-project")]
        public async Task<ActionResult> CreateProject([FromBody] CreateProjectDto createProjectDto)
        {
            var command = _mapper.Map<CreateProjectCommand>(createProjectDto);
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }
        /// <summary>
        /// Creates task
        /// </summary>
        [HttpPost("create-task")]
        public async Task<ActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            var taskId = await Mediator.Send(command);
            return Ok(taskId);
        }

        /// <summary>
        /// Updates project information
        /// </summary>
        [HttpPut("update-project")]
        public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectDto updateProjectDto)
        {
            var command = _mapper.Map<UpdateProjectCommand>(updateProjectDto);
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Updates task information
        /// </summary>
        [HttpPut("update-task")]
        public async Task<IActionResult> UpdateTask([FromBody]UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes project
        /// </summary>
        [HttpDelete("delete-project/{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var command = new DeleteProjectCommand
            {
                Id = projectId

            };
            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Deletes task
        /// </summary>
        [HttpDelete("delete-task/{taskId}")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var command = new DeleteTaskCommand
            {
                Id = taskId

            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}