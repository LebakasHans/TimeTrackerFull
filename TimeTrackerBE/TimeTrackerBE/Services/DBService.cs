namespace TimeTrackerBE.Services;

public class DBService(TimeTrackerProContext db)
{
    public List<EmployeeDto> GetEmployees()
    {
        return db.Employees.Select(x => new EmployeeDto
        {
            Id = x.Id,
            Name = $"{x.Firstname} {x.Lastname}",
            Birthdate = x.Birthdate,
            HoursOfWork = x.HoursOfWork
        }).ToList();
    }

    public List<ProjectScheduleDto> GetProjectSchedules(int employeeId)
    {
        return db.ProjectScheduleTimes.Select(x => new ProjectScheduleDto
        {
            Id = x.Id,
            ProjectId = x.ProjectId,
            EmployeeId = x.EmployeeId,
            ActivityId = x.ActivityId,
            Description = x.Description,
            EmployeeName = x.Employee.Firstname + " " + x.Employee.Lastname,
            ProjectName = x.Project.Name,
            ActivityName = x.Activity.Name,
            StartDate = x.StartDateTime,
            EndDate = x.EndDateTime
        })
        .Where(x => x.EmployeeId == employeeId)
        .ToList();
    }

    public List<ProjectDto> GetProjects()
    {
        return db.Projects.Select(x => new ProjectDto
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }

    public List<ActivityDto> GetActivities()
    {
        return db.Activities.Select(x => new ActivityDto
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }

    public ProjectScheduleDto AddProjectSchedule(ProjectScheduleRessource psr)
    {
        var projectSchedule = new ProjectScheduleTime
        {
            ProjectId = psr.ProjectId,
            EmployeeId = psr.EmployeeId,
            ActivityId = psr.ActivityId,
            StartDateTime = psr.StartDate,
            EndDateTime = psr.EndDate,
            Description = psr.Description
        };

        db.ProjectScheduleTimes.Add(projectSchedule);
        db.SaveChanges();

        return new ProjectScheduleDto
        {
            Id = projectSchedule.Id,
            ProjectId = projectSchedule.ProjectId,
            EmployeeId = projectSchedule.EmployeeId,
            ActivityId = projectSchedule.ActivityId,
            Description = projectSchedule.Description,
            EmployeeName = projectSchedule.Employee.Firstname + " " + projectSchedule.Employee.Lastname,
            ProjectName = projectSchedule.Project.Name,
            ActivityName = projectSchedule.Activity.Name,
            StartDate = projectSchedule.StartDateTime,
            EndDate = projectSchedule.EndDateTime
        };
    }

    public ProjectScheduleDto DeleteProjectSchedule(long id)
    {
        var projectSchedule = db.ProjectScheduleTimes.Find(id);
        db.ProjectScheduleTimes.Remove(projectSchedule);
        db.SaveChanges();

        return new ProjectScheduleDto
        {
            Id = projectSchedule.Id,
            ProjectId = projectSchedule.ProjectId,
            EmployeeId = projectSchedule.EmployeeId,
            ActivityId = projectSchedule.ActivityId,
            Description = projectSchedule.Description,
            EmployeeName = projectSchedule.Employee.Firstname + " " + projectSchedule.Employee.Lastname,
            ProjectName = projectSchedule.Project.Name,
            ActivityName = projectSchedule.Activity.Name,
            StartDate = projectSchedule.StartDateTime,
            EndDate = projectSchedule.EndDateTime
        };
    }

    public ProjectScheduleDto UpdateProjectSchedule(long id, ProjectScheduleRessource psr)
    {
        var projectSchedule = db.ProjectScheduleTimes.Find(id);
        projectSchedule.ProjectId = psr.ProjectId;
        projectSchedule.EmployeeId = psr.EmployeeId;
        projectSchedule.ActivityId = psr.ActivityId;
        projectSchedule.StartDateTime = psr.StartDate;
        projectSchedule.EndDateTime = psr.EndDate;
        projectSchedule.Description = psr.Description;

        db.SaveChanges();
        
        return new ProjectScheduleDto
        {
            Id = projectSchedule.Id,
            ProjectId = projectSchedule.ProjectId,
            EmployeeId = projectSchedule.EmployeeId,
            ActivityId = projectSchedule.ActivityId,
            Description = projectSchedule.Description,
            EmployeeName = projectSchedule.Employee.Firstname + " " + projectSchedule.Employee.Lastname,
            ProjectName = projectSchedule.Project.Name,
            ActivityName = projectSchedule.Activity.Name,
            StartDate = projectSchedule.StartDateTime,
            EndDate = projectSchedule.EndDateTime
        };
    }
}
