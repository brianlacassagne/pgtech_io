using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using PGTech_io.Data;

namespace PGTech_io.Models;

public partial class Send
{
    public int Id { get; set; }
    public string? Client { get; set; }
    public string? Iduser { get; set; }
    
    public int Idsector { get; set; }
    
    public int IdSubsector { get; set; }
    public string? Problemdescription { get; set; }
    public DateOnly Createdwhen { get; set; }
    public DateOnly? Updatedwhen { get; set; }
    public virtual ApplicationUser? IduserNavigation { get; set; }
    public virtual Sector? IdsectorNavigation { get; set; }
    
    public virtual Subsector? IdsubsectorNavigation { get; set; }
    public virtual ICollection<Documentation> Documentations { get; set; } = new List<Documentation>();
    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();
    
    
    public Send()
    {
        Createdwhen = DateOnly.FromDateTime(DateTime.UtcNow);
    }
    
    //----------------------------------------------------------------------------------------

    public string IsResponded()
    {
        return Responses.Any() ? "Contestado" : "";
    }
    
    public override string ToString()
    {
        return $"{Id} {Client}";
    }
}
