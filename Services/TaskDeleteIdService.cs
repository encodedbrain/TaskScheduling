using TaskScheduling.Data;

namespace TaskScheduling.Services;

class TaskDeleteService
{
    public async Task<bool> TaskDelete(int id)
    {

        using (var context = new TaskSchedulingDb())
        {

            var task = context.Tasks.FirstOrDefault(task => task.Id == id);

            if (task is null) return false;

            context.Tasks.Remove(task);
            await context.SaveChangesAsync();

        }
        return true;
    }
}