using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Recipe
{
    public int IdRecipe { get; set; }

    public int MedicamentIdMedicament { get; set; }

    public int EmployeeIdEmployee { get; set; }

    public string RecipeDateTo { get; set; } = null!;

    public virtual Employee EmployeeIdEmployeeNavigation { get; set; } = null!;

    public virtual Medicament MedicamentIdMedicamentNavigation { get; set; } = null!;

    public virtual ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
}
