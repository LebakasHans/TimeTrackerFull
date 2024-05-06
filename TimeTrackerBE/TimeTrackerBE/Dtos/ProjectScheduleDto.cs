namespace TimeTrackerBE.Dtos;

public class ProjectScheduleDto
{
    public long Id { get; set; }
    public int ProjectId { get; set; }
    public int EmployeeId { get; set; }
    public int ActivityId { get; set; }
    public string Description { get; set; } 
    public string EmployeeName { get; set; }
    public string ProjectName { get; set; }
    public string ActivityName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}
