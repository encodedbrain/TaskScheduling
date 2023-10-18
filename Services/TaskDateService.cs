using TaskScheduling.Data;

namespace TaskScheduling.Services;

internal class TaskDateService
{
    public object TaskDate(DateTime date)
    {
        using (var context = new TaskSchedulingDb())
        {
            var task = context.Tasks.FirstOrDefault(
                task => task.Date == date);
            if (task is null) return false;

            return task;
        }
    }
}