using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Product
{
    public int Pkid { get; set; }

    public int Quantity { get; set; }

    public int UnitPrice { get; set; }

    public string Category { get; set; } = null!;

    public string Name { get; set; } = null!;

    public byte[]? ProductImage { get; set; }
}
