using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class ProductionStatus
{
    public int Pkid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Production> Productions { get; set; } = new List<Production>();
}
