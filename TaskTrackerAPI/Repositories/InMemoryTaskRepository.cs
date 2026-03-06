using TaskTrackerAPI.Domain;

namespace TaskTrackerAPI.Repositories;

public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<BaseTask> _tasks = new();

    public IEnumerable<BaseTask> GetAll()
    {
        return _tasks;
    }

    public BaseTask? GetById(Guid id)
    {
        return _tasks.FirstOrDefault(t => t.Id == id);
    }

    public void Add(BaseTask task)
    {
        _tasks.Add(task);
    }

    public bool Complete(Guid id)
    {
        var task = GetById(id);
        if (task == null)
            return false;

        task.OnTaskCompleted += task =>
        {
            Console.WriteLine($"Task completed: {task.Title}");
        };

        task.CompleteTask();
        return true;
    }
}