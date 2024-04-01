using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Sender
{
    public int Pkid { get; set; }

    public string Role { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Novelty> Novelties { get; set; } = new List<Novelty>();
}
