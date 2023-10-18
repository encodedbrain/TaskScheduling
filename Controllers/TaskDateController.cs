using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;


[ApiController]
[Route("v1")]
public class TaskDateController : ControllerBase

{
    [HttpGet]
    [Route("task/getbydata")]
    public Task<IActionResult> TaskDate([FromQuery] DateTime prop)
    {
        var service = new TaskDateService();
        var status = service.TaskDate(prop);
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok(status));
    }
}