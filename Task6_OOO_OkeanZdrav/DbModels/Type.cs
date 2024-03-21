using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Type
{
    public int IdType { get; set; }

    public string TypeName { get; set; } = null!;

    public virtual ICollection<Medicament> Medicaments { get; set; } = new List<Medicament>();
}
