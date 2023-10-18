using TaskScheduling.Data;

namespace TaskScheduling.Services;

internal class TaskReadService
{
    public object TaskReadAll()
    {
        using (var context = new TaskSchedulingDb())
        {
            var task = context.Tasks.Select(task => task);

            foreach (var value in task)
                return new
                {
                    value
                };
        }

        return true;
    }
}