using System;
using System.Collections.Generic;

namespace PGTech_io.Models;

public partial class Subsector
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Idsector { get; set; }

    public virtual Sector IdsectorNavigation { get; set; } = null!;
    
    public override bool Equals(object? obj)
    {
        return obj is Subsector s && s.Id == Id;
    }

    public override int GetHashCode()  => Id.GetHashCode();

    public override string ToString()
    {
        return base.ToString();
    }
}
