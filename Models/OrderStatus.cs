using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class OrderStatus
{
    public int Pkid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
