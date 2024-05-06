using System;
using System.Collections.Generic;

namespace TimeTrackerProDb;

public partial class Activity
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ProjectScheduleTime> ProjectScheduleTimes { get; set; } = new List<ProjectScheduleTime>();
}
