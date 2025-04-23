using System;
using System.Collections.Generic;

namespace SellerPlatform.Model;

public partial class Cart
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public int? Quantity { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Product? Product { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
