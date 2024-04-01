using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class InventoriesSupply
{
    public int FkInventoriesId { get; set; }

    public int FkSuppliesId { get; set; }

    public virtual Supply FkInventories { get; set; } = null!;

    public virtual Inventory FkSupplies { get; set; } = null!;
}
