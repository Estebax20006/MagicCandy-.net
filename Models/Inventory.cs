using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Inventory
{
    public DateOnly? EntryDate { get; set; }

    public int? EntryQuantity { get; set; }

    public DateOnly? ExitDate { get; set; }

    public int? ExitQuantity { get; set; }

    public DateOnly? ExpirationDate { get; set; }

    public int Pkid { get; set; }

    public int? TotalQuantity { get; set; }

    public string? ExitDescription { get; set; }
}
