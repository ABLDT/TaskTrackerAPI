using TaskTrackerAPI.Domain;

namespace TaskTrackerAPI.Services;

public static class TaskFilterService
{
    public static List<BugReportTask> GetHighSeverityBugs(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<BugReportTask>()
            .Where(t => !t.IsCompleted && t.SeverityLevel >= 8)
            .OrderByDescending(t => t.CreatedAt)
            .ToList();
    }

    public static int GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .OfType<FeatureRequestTask>()
            .Where(t => !t.IsCompleted)
            .Sum(t => t.EstimatedHours);
    }
}