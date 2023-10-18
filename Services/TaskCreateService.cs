using TaskScheduling.Data;
using TaskScheduling.Models;
using TaskScheduling.Schemas;

namespace TaskScheduling.Services;

class TaskCreateService
{
public async Task<bool> TaskCreate(SchemaTask prop )
{
    using (var context = new TaskSchedulingDb())
    {

        var task = new TaskModel()
        {
            Title = prop.Title,
            Description = prop.Description,
            Date = DateTime.Now,
            Status = TaskModel.StatusTask.Pending,
        };

        await context.Tasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    return true;
}
}