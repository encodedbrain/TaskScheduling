using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Schemas;
using TaskScheduling.Services;

namespace TaskScheduling.Controllers;


[ApiController]
[Route("v1")]
public class UserCreateController : ControllerBase
{
    [HttpPost]
    [Route("user")]
    [AllowAnonymous]
    public Task<IActionResult> UserCreate([FromBody] SchemaPost prop)
    {
        var service = new UserCreateService();
        var status = service.UserCreate(prop).Result;
        
        if (status is false) return Task.FromResult<IActionResult>(BadRequest("operation not performed"));
        return Task.FromResult<IActionResult>(Ok($"operation carried out successfully"));
    }
}