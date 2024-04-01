using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Ingredient
{
    public int FkProductionsId { get; set; }

    public int FkSuppliesId { get; set; }

    public int Pkid { get; set; }

    public int SetAmount { get; set; }

    public virtual Production FkProductions { get; set; } = null!;

    public virtual Supply FkSupplies { get; set; } = null!;
}
