using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class ActivityManager
{
    public int Pkid { get; set; }

    public string Role { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
