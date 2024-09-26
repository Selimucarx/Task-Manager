using Microsoft.AspNetCore.Mvc;
using TaskManager.Dtos;
using TaskManager.Services;

namespace TaskManager.Controllers;

[ApiController]
[Route("api/tasks")]
public class TaskController(UserTaskService taskService) : ControllerBase
{
    [HttpPost]
    public IActionResult CreateTask([FromHeader] string Authorization, [FromBody] CreateTaskDto taskDto)
    {
        var token = Authorization.Replace("Bearer ", "");
        taskService.CreateTask(token, taskDto);
        return Ok(new { message = "Görev oluşturuldu" });
    }

    [HttpDelete("{taskId}")]
    public IActionResult DeleteTask([FromHeader] string Authorization, Guid taskId)
    {
        try
        {
            var token = Authorization.Replace("Bearer ", "");
            taskService.DeleteTask(token, taskId);
            return Ok(new { message = "Görev silindi" });
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { message = ex.Message });
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}