namespace TimeTrackerBE.Controllers;

public class AllController(DBService dbService) : Controller
{
    [HttpGet("employees")]
    public List<EmployeeDto> GetEmployees()
    {
        return dbService.GetEmployees();
    }

    [HttpGet("projectschedules")]
    public List<ProjectScheduleDto> GetProjectSchedules(int employeeId)
    {
        return dbService.GetProjectSchedules(employeeId);
    }

    [HttpGet("project")]
    public List<ProjectDto> GetProject()
    {
        return dbService.GetProjects();
    }

    [HttpGet("activity")]
    public List<ActivityDto> GetActivity()
    {
        return dbService.GetActivities();
    }

    [HttpPost("projectschedule")]
    public ProjectScheduleDto AddProjectSchedule(ProjectScheduleRessource psr)
    {
        return dbService.AddProjectSchedule(psr);
    }

    [HttpDelete("projectschedule/{id}")]
    public ProjectScheduleDto DeleteProjectSchedule(int id)
    {
        return dbService.DeleteProjectSchedule(id);
    }

    [HttpPut("projectschedule/{id}")]
    public ProjectScheduleDto UpdateProjectSchedule(long id, ProjectScheduleRessource psr)
    {
        return dbService.UpdateProjectSchedule(id, psr);
    }
}
