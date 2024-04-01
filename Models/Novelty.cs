using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Novelty
{
    public DateOnly Date { get; set; }

    public int FkNoveltyStatesId { get; set; }

    public int FkProductionsId { get; set; }

    public int FkReferredId { get; set; }

    public int FkSendersId { get; set; }

    public int Pkid { get; set; }

    public TimeOnly Time { get; set; }

    public string Subject { get; set; } = null!;

    public string Comment { get; set; } = null!;

    public virtual NoveltyStatus FkNoveltyStates { get; set; } = null!;

    public virtual Production FkProductions { get; set; } = null!;

    public virtual Referral FkReferred { get; set; } = null!;

    public virtual Sender FkSenders { get; set; } = null!;
}
