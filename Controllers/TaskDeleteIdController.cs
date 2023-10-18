using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;


[ApiController]
[Route("v1")]
public class TaskDeleteIdController : ControllerBase
{
    [HttpDelete]
    [Route("task/{id}")]
    public Task<IActionResult> TaskDelete([FromRoute]int id)
    {
        var service = new TaskDeleteService();
        var status = service.TaskDelete(id).Result;

        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok($"operation carried out successfully"));
    }
}