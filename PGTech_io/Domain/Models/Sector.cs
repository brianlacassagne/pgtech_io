using System;
using System.Collections.Generic;

namespace PGTech_io.Models;

public partial class Sector
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public virtual ICollection<Subsector> Subsectors { get; set; } = new List<Subsector>();
    
    public virtual ICollection<Send> Sends { get; set; } = new List<Send>();

    public override string ToString()
    {
        return string.IsNullOrWhiteSpace(Name) ? Name : "";
    }
    
    public override bool Equals(object? obj)
    {
        return obj is Sector s && s.Id == Id;
    }

    public override int GetHashCode()  => Id.GetHashCode();
}
