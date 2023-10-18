using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;



[ApiController]
[Route("v1")]
public class TaskStatusController : ControllerBase
{
    [HttpGet]
    [Route("task/getbystatus")]
    public Task<IActionResult> TaskStatus([FromQuery] int id
    )
    {
        var service = new TaskStatusService();
        var status = service.TaskStatus(id);
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok(status));
    }
}