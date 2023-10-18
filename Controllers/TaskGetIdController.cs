using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;


[ApiController]
[Route("v1")]
public class TaskGetIdController : ControllerBase

{
    [HttpGet]
    [Route("task/{id}")]
    public Task<IActionResult> TaskGetId([FromRoute]int id)
    {
        var service = new TaskGetIdService();
        var status = service.TaskGetId(id);
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok(status));
    }
}