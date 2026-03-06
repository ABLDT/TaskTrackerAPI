namespace TaskTrackerAPI.Dtos;

public class CreateBugReportTaskDto
{
    public string Title { get; set; } = string.Empty;
    public int SeverityLevel { get; set; }
}