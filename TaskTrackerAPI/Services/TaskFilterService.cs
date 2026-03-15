using TaskTrackerAPI.Domain;

namespace TaskTrackerAPI.Services;

public static class TaskFilterService
{
    public static List<BugReportTask> GetHighSeverityBugs(IEnumerable<BaseTask> tasks)
    {
        return tasks
            .Where(task => task is BugReportTask { SeverityLevel: >= 8, IsCompleted: false })
            .Cast<BugReportTask>()
            .OrderByDescending(t => t.CreatedAt)
            .ToList();
    }

    public static int GetTotalEstimatedHours(IEnumerable<BaseTask> tasks)
    {
        return tasks.Sum(task =>
            task switch
            {
                FeatureRequestTask feature when !feature.IsCompleted => feature.EstimatedHours,
                _ => 0
            });
    }
}