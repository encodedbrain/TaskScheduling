using TaskScheduling.Models;

namespace TaskScheduling.Schemas;

public class SchemaGet
{
    public string Email { get; set; }
    public string Password { get; set; }
    public DateTime Date { get; set; }
    public string Title { get; set; }
    public string Update { get; set; }
    public TaskModel.status Status { get; set; }
}