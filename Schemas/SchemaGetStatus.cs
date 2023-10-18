using TaskScheduling.Models;

namespace TaskScheduling.Schemas;

public class SchemaGetStatus
{
    public string Email { get; set; }
    public string Password { get; set; }
    public TaskModel.status Status { get; set; }
}