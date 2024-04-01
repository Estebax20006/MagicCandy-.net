using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class ProductsInventory
{
    public int FkInventoriesId { get; set; }

    public int FkProductsId { get; set; }

    public virtual Inventory FkInventories { get; set; } = null!;

    public virtual Product FkProducts { get; set; } = null!;
}
