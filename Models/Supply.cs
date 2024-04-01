using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Supply
{
    public int Pkid { get; set; }

    public int Quantity { get; set; }

    public string Category { get; set; } = null!;

    public string Unit { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
