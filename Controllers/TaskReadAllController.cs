using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;



[ApiController]
[Route("v1")]
public class TaskReadAllController : ControllerBase
{
    [HttpGet]
    [Route("task/getall")]
    public Task<IActionResult> TaskReadAll()
    {
        var service = new TaskReadService();
        var status = service.TaskReadAll();
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok(status));
    }
}