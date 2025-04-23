using System;
using System.Collections.Generic;

namespace SellerPlatform.Model;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public bool? Subscription { get; set; }

    public int? CartId { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
