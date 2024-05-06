using System;
using System.Collections.Generic;

namespace TimeTrackerProDb;

public partial class WorkScheduleTime
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public string Description { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
