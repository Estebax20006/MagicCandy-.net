using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class Role
{
    public int Pkid { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
