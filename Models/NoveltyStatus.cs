using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class NoveltyStatus
{
    public int Pkid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Novelty> Novelties { get; set; } = new List<Novelty>();
}
