using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Order
{
    public DateOnly DateRequest { get; set; }

    public int FkOrderStatusesId { get; set; }

    public int FkUsersId { get; set; }

    public int Pkid { get; set; }

    public int Quantity { get; set; }

    public float Value { get; set; }

    public string Detail { get; set; } = null!;

    public virtual OrderStatus FkOrderStatuses { get; set; } = null!;

    public virtual User FkUsers { get; set; } = null!;

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
