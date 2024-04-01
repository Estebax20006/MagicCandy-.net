using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Sale
{
    public int DeliveryQuantity { get; set; }

    public int FkOrdersId { get; set; }

    public int Pkid { get; set; }

    public TimeOnly SaleTime { get; set; }

    public int Value { get; set; }

    public DateOnly SaleDate { get; set; }

    public string Detail { get; set; } = null!;

    public byte[] Receipt { get; set; } = null!;

    public virtual Order FkOrders { get; set; } = null!;
}
