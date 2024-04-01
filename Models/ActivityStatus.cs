using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class ActivityStatus
{
    public int Pkid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
