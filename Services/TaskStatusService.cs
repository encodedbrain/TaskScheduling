using TaskScheduling.Data;
using TaskScheduling.Models;

namespace TaskScheduling.Services;

internal class TaskStatusService
{
    public object TaskStatus(int status)
    {
        using (var context = new TaskSchedulingDb())
        {
            var task = context.Tasks.FirstOrDefault(task => task.Status == (TaskModel.StatusTask)status);

            if (task is null) return false;

            return task;
        }
    }
}