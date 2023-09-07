using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Models;
using TaskManagement.Repository.Implementations;
using TaskManagement.Repository.Interfaces;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUserController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskUserController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks  = await _taskRepository.GetAll();
            return Ok(tasks);
        }


        [HttpPost]
        public async Task<IActionResult> AddTask(TaskUser taskUser)
        {
            await _taskRepository.Add(taskUser);
            return CreatedAtAction(nameof(GetById), new { id = taskUser.Id }, taskUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskUser>> GetById(int id)
        {
            var task = await _taskRepository.GetById(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        [HttpGet("by-user/{userId}")]
        public async Task<IActionResult> GetTasksByUserId(int userId)
        {
            try
            {
                var tasks = await _taskRepository.GetTasksByUserIdAsync(userId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
