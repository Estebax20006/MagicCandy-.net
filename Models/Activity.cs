using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Activity
{
    public int FkActivityManagersId { get; set; }

    public int FkActivityStatusesId { get; set; }

    public int FkProductionId { get; set; }

    public int Pkid { get; set; }

    public DateOnly? EndDate { get; set; }

    public DateOnly StartDate { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ActivityManager FkActivityManagers { get; set; } = null!;

    public virtual ActivityStatus FkActivityStatuses { get; set; } = null!;

    public virtual Production FkProduction { get; set; } = null!;
}
