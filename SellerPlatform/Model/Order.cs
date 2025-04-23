using System;
using System.Collections.Generic;

namespace SellerPlatform.Model;

public partial class Order
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int PostCode { get; set; }

    public string City { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string HouseNumber { get; set; } = null!;

    public string? Note { get; set; }

    public int? UserId { get; set; }

    public int? CartId { get; set; }

    public int? ProductId { get; set; }

    public virtual Cart? Cart { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
