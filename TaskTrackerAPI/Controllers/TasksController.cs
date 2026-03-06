using Microsoft.AspNetCore.Mvc;
using TaskTrackerAPI.Domain;
using TaskTrackerAPI.Dtos;
using TaskTrackerAPI.Repositories;

namespace TaskTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var tasks = _repository.GetAll();
        return Ok(tasks);
    }

    [HttpPost("bug")]
    public IActionResult CreateBug([FromBody] CreateBugReportTaskDto dto)
    {
        var bugTask = new BugReportTask(dto.Title, dto.SeverityLevel);
        _repository.Add(bugTask);
        return Ok(bugTask);
    }

    [HttpPut("{id}/complete")]
    public IActionResult CompleteTask(Guid id)
    {
        var result = _repository.Complete(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}