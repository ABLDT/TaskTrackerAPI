namespace TaskTrackerAPI.Domain;

public class BugReportTask : BaseTask
{
    public int SeverityLevel { get; set; }

    public BugReportTask(string title, int severityLevel)
        : base(title)
    {
        SeverityLevel = severityLevel;
    }
}