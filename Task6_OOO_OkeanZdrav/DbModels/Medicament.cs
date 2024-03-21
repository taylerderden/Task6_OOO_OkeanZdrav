using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Medicament
{
    public int IdMedicament { get; set; }

    public string MedicamentName { get; set; } = null!;

    public int MedicamentCost { get; set; }

    public string? MedicamentDiscount { get; set; }

    public int? MedicamentCount { get; set; }

    public string MedicamentPart { get; set; } = null!;

    public int SupplierIdSupplier { get; set; }

    public int TypeIdType { get; set; }

    public byte[]? MedicamentImage { get; set; }

    public string? MedicamentAnalog { get; set; }

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

    public virtual Supplier SupplierIdSupplierNavigation { get; set; } = null!;

    public virtual Type TypeIdTypeNavigation { get; set; } = null!;
}
