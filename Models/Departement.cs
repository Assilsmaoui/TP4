using System;
using System.Collections.Generic;

namespace TP4.Models;

public partial class Departement
{
    public int IdDepartement { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
