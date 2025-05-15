using System;
using System.Collections.Generic;
using PGTech_io.Data;

namespace PGTech_io.Models;

public partial class Response
{
    public int Id { get; set; }

    public string Solutiondescription { get; set; } = null!;

    public DateOnly Createdwhen { get; set; }

    public DateOnly? Updatedwhen { get; set; }

    public string? Iduser { get; set; }

    public int Idsolicitation { get; set; }

    public virtual Send IdsolicitationNavigation { get; set; } = null!;

    public virtual ApplicationUser? IduserNavigation { get; set; }

    public Response()
    {
        Createdwhen = DateOnly.FromDateTime(DateTime.UtcNow);
    }
}
