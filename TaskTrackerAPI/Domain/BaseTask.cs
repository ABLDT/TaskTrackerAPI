namespace TaskTrackerAPI.Domain;

public abstract class BaseTask
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Title { get; set; }
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public bool IsCompleted { get; private set; }

    public delegate void TaskCompletedHandler(BaseTask task);
    public event TaskCompletedHandler? OnTaskCompleted;

    protected BaseTask(string title)
    {
        Title = title;
    }

    public void CompleteTask()
    {
        if (!IsCompleted)
        {
            IsCompleted = true;
            OnTaskCompleted?.Invoke(this);
        }
    }
}