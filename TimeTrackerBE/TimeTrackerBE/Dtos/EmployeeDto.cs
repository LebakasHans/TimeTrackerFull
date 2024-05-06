namespace TimeTrackerBE.Dtos;

public class EmployeeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly? Birthdate { get; set; }
    public int HoursOfWork { get; set; }
}
