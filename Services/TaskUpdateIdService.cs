using TaskScheduling.Data;
using TaskScheduling.Schemas;

namespace TaskScheduling.Services;

internal class TaskUpdateService
{
    public async Task<bool> TaskUpdate(SchemaTask prop, int id
    )
    {
        using (var context = new TaskSchedulingDb())
        {
            var task = context.Tasks.FirstOrDefault(
                task => task.Id == id);

            if (task is null) return false;

            task.Description = prop.Description;
            task.Title = prop.Title;
            task.Date = prop.Date;
            task.Status = prop.Status;

            context.Tasks.Update(task);
            await context.SaveChangesAsync();
        }

        return true;
    }
}