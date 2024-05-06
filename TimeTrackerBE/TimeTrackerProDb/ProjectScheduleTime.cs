using System;
using System.Collections.Generic;

namespace TimeTrackerProDb;

public partial class ProjectScheduleTime
{
    public long Id { get; set; }

    public int EmployeeId { get; set; }

    public int ProjectId { get; set; }

    public int ActivityId { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public string Description { get; set; } = null!;

    public virtual Activity Activity { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual Project Project { get; set; } = null!;
}
