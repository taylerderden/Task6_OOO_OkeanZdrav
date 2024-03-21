using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Supplier
{
    public int IdSupplier { get; set; }

    public string SupplierName { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
