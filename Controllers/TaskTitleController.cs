using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;


[ApiController]
[Route("v1")]
public class TaskTitleController : ControllerBase
{
    [HttpGet]
    [Route("task/getbytitle")]
    public Task<IActionResult> TaskTitle([FromQuery] string prop)
    {
        var service = new TaskTitleService();
        var status = service.TaskTitle(prop);
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok(status));
    }
}