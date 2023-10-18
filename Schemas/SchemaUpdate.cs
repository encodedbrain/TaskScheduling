using TaskScheduling.Models;

namespace TaskScheduling.Schemas;

public class SchemaUpdate
{
    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public TaskModel.status Status { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int Identifier { get; set; }
}