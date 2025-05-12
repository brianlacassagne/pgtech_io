using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PGTech_io.Data;
using PGTech_io.Interfaces;

namespace PGTech_io.Models;

public partial class Sender : IMessageType
{
    [Key] public int Id { get; set; }
    public string? Client { get; set; }
    public string? Iduser { get; set; } // = null!;
    public string? Sector { get; set; }
    public string? Subsector { get; set; }
    public string? Problemdescription { get; set; }
    public DateOnly Createdwhen { get; set; }
    public DateOnly? Updatedwhen { get; set; }
    public virtual ICollection<Documentation> Documentations { get; set; } = new List<Documentation>();
    public virtual ApplicationUser IduserNavigation { get; set; } = null!;
    public virtual ICollection<Response> Responses { get; set; } = new List<Response>();
    
    //-----------------------------------------------------------------------------------------
    
    public Sender()
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

//-----------------------------------------------------------------------------------------
}
