using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Purchase
{
    public int IdPurchase { get; set; }

    public DateOnly PurchaseDate { get; set; }

    public int MedicamentIdMedicament { get; set; }

    public string? PurchaseCount { get; set; }

    public int ClientsIdClients { get; set; }

    public int? RecipeIdRecipe { get; set; }

    public virtual Client ClientsIdClientsNavigation { get; set; } = null!;

    public virtual Medicament MedicamentIdMedicamentNavigation { get; set; } = null!;

    public virtual Recipe? RecipeIdRecipeNavigation { get; set; }
}
