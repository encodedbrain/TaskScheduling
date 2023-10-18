using TaskScheduling.Models;

namespace TaskScheduling.Schemas;

public class SchemaTask
{
    public SchemaTask(string title, string description, DateTime date, TaskModel.StatusTask status)
    {
        Title = title;
        Description = description;
        Date = date;
        Status = status; 
    }

    public string Title { get; set; }

    public string Description { get; set; }

    public DateTime Date { get; set; }

    public TaskModel.StatusTask Status { get; set; }
}