using Microsoft.AspNetCore.Mvc;
using TaskApi.Dtos;
using TaskApi.Interfaces;

namespace TaskApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // GET: api/Tasks?status=Dang%20lam
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks([FromQuery] string? status)
    {
        var tasks = await _taskService.GetAllAsync(status);
        return Ok(tasks);
    }

    // POST: api/Tasks
    [HttpPost]
    public async Task<ActionResult<TaskDto>> PostTask(CreateTaskDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var task = await _taskService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

    // PUT: api/Tasks/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTask(int id, UpdateTaskDto dto)
    {
        var updatedTask = await _taskService.UpdateAsync(id, dto);

        if (updatedTask == null)
        {
            return NotFound();
        }

        return NoContent(); // Cập nhật thành công, trả về 204
    }

    // DELETE: api/Tasks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTask(int id)
    {
        var isDeleted = await _taskService.DeleteAsync(id);

        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}