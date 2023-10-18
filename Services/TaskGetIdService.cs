using TaskScheduling.Data;

namespace TaskScheduling.Services;

class TaskGetIdService
{
    public object TaskGetId(int id)
    {
        using (var context = new TaskSchedulingDb())
        {
            var task = context.Tasks.FirstOrDefault(task => task.Id == id);

            if (task is null) return false;

            return task;
        }
    }
}