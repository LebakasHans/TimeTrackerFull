namespace TimeTrackerBE.Dtos;

public class ProjectScheduleRessource
{
    public int ProjectId { get; set; }
    public int EmployeeId { get; set; }
    public int ActivityId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Description { get; set; }

}
