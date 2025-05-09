using System;
using System.Collections.Generic;

namespace PGTech_io.Models;

public partial class Sector
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Subsector> Subsectors { get; set; } = new List<Subsector>();
}
