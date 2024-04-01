using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Production
{
    public int FkProductionStatementsId { get; set; }

    public int Pkid { get; set; }

    public int QuantityProduce { get; set; }

    public DateOnly EndDate { get; set; }

    public DateOnly StartDate { get; set; }

    public string ProductQuality { get; set; } = null!;

    public string Lot { get; set; } = null!;

    public string ProductProduce { get; set; } = null!;

    public string Observations { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual ProductionStatus FkProductionStatements { get; set; } = null!;

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<Novelty> Novelties { get; set; } = new List<Novelty>();
}
