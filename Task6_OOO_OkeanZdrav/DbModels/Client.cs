using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Client
{
    public int IdClients { get; set; }

    public string ClientSurname { get; set; } = null!;

    public string ClientName { get; set; } = null!;

    public string ClientMiddlename { get; set; } = null!;

    public string ClientPhone { get; set; } = null!;

    public string ClientEmail { get; set; } = null!;

    public string ClientDiscountPercent { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
