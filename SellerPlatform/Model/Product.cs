using System;
using System.Collections.Generic;

namespace SellerPlatform.Model;

public partial class Product
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int StorageQuantity { get; set; }

    public int? SoldQuantity { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
