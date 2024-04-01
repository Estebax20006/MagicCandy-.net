using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class OrdersProduct
{
    public int FkOrdersId { get; set; }

    public int FkProductsId { get; set; }

    public virtual Order FkOrders { get; set; } = null!;

    public virtual Product FkProducts { get; set; } = null!;
}
