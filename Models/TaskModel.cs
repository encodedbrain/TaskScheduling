namespace TaskScheduling.Models;

public class TaskModel
{
    public enum StatusTask
    {
        Pending = 0,
        Complete = 1
    }
    
    public int  Id { get; set; }

    public TaskModel(string? title, string? description, DateTime date, StatusTask value)
    {
        Title = title;
        Description = description;
        Date = date;
        Status = value;
    }

    public TaskModel()
    {
    }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime Date { get; set; }
    public StatusTask Status { get; set; }
}