using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Models;
using TaskManager.Api.Services;

namespace TaskManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAll()
        {
            var tasks = await _service.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<TaskItem>>> GetByUser(int userId)
        {
            var tasks = await _service.GetByUserIdAsync(userId);
            return Ok(tasks);
        }

        [HttpGet("uncompleted")]
        public async Task<ActionResult<List<TaskItem>>> GetUncompleted()
        {
            var tasks = await _service.GetUncompletedAsync();
            return Ok(tasks);
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create(TaskItem task)
        {
            var created = await _service.CreateAsync(task);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TaskItem task)
        {
            var result = await _service.UpdateAsync(id, task);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPut("{id}/toggle")]
        public async Task<IActionResult> ToggleComplete(int id)
        {
            var result = await _service.ToggleCompleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
