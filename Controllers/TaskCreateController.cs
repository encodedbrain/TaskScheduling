using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Schemas;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;

[ApiController]
[Route("v1")]
public class TaskCreateController : ControllerBase
{
    [HttpPost]
    [Route("task")]
    public Task<IActionResult> TaskCreate([FromBody] SchemaTask prop )
    {
        var service = new TaskCreateService();
        
        var status = service.TaskCreate(prop).Result;
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok($"operation carried out successfully"));
    }
}