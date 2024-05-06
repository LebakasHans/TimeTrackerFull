using System;
using System.Collections.Generic;

namespace TimeTrackerProDb;

public partial class Project
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MaximumHours { get; set; }

    public virtual ICollection<ProjectScheduleTime> ProjectScheduleTimes { get; set; } = new List<ProjectScheduleTime>();
}
