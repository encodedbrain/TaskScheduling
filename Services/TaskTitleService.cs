using TaskScheduling.Data;

namespace TaskScheduling.Services;

internal class TaskTitleService
{
    public object TaskTitle(string title)
    {
        using (var context = new TaskSchedulingDb())
        {
            var task = context.Tasks.FirstOrDefault(task => task.Title == title);

            if (task is null) return false;

            return task;
        }

      
    }
}