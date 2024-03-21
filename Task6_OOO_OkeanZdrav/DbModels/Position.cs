using System;
using System.Collections.Generic;

namespace Task6_OOO_OkeanZdrav.DbModels;

public partial class Position
{
    public int IdPosition { get; set; }

    public string PositionName { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
