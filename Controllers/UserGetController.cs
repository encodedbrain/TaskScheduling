using Microsoft.AspNetCore.Mvc;
using TaskScheduling.Schemas;

namespace TaskScheduling.Controllers;

[ApiController]
[Route("v1")]
public class UserGetController : ControllerBase
{
    [HttpGet]
    [Route("user")]
    public Task<IActionResult> UserGet( [FromQuery] SchemaUserGet prop)
    {
        var service = new UserGetController();
        var status = service.UserGet(prop).Result;
        return Task.FromResult<IActionResult>(Ok(status));
    }
}