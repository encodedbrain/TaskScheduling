using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Schemas;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;
 

[ApiController]
[Route("v1")]
public class TaskUpdateIdCotroller : ControllerBase
{
    [HttpPut]
    [Route("task/{id}")]
    public Task<IActionResult> TaskUpdate([FromRoute] int id , [FromBody] SchemaTask prop)
    {
    var service = new TaskUpdateService();
    var status = service.TaskUpdate(prop,id).Result;
    
    if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok($"operation carried out successfully"));
    }
}