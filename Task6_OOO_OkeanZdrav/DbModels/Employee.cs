using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Employee
{
    public int IdEmployee { get; set; }

    public string EmployeeSurname { get; set; } = null!;

    public string EmployeeName { get; set; } = null!;

    public string EmployeeMiddleName { get; set; } = null!;

    public int PositionIdPosition { get; set; }

    public string EmployeePhone { get; set; } = null!;

    public string EmployeeEmail { get; set; } = null!;

    public string EmployeePassword { get; set; } = null!;

    public virtual Position PositionIdPositionNavigation { get; set; } = null!;

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
