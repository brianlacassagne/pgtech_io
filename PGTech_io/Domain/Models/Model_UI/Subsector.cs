using System;
using System.Collections.Generic;

namespace PGTech_io.Models;

public partial class Subsector
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Idsector { get; set; }

    public virtual Sector IdsectorNavigation { get; set; } = null!;
}
