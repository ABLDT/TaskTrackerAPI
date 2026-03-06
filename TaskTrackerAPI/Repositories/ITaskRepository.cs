using TaskTrackerAPI.Domain;

namespace TaskTrackerAPI.Repositories;

public interface ITaskRepository
{
    IEnumerable<BaseTask> GetAll();
    BaseTask? GetById(Guid id);
    void Add(BaseTask task);
    bool Complete(Guid id);
}