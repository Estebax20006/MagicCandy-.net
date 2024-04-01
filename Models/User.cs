using System;
using System.Collections.Generic;

namespace MagicCandy.Models;

public partial class User
{
    public int FkRolesId { get; set; }

    public int Pkid { get; set; }

    public string Identification { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual Role FkRoles { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
