using System;
using System.Collections.Generic;

namespace TimeTrackerProDb;

public partial class Employee
{
    public int Id { get; set; }

    public DateOnly? Birthdate { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public int HoursOfWork { get; set; }

    public virtual ICollection<ProjectScheduleTime> ProjectScheduleTimes { get; set; } = new List<ProjectScheduleTime>();

    public virtual ICollection<WorkScheduleTime> WorkScheduleTimes { get; set; } = new List<WorkScheduleTime>();
}
