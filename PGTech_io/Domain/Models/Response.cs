using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PGTech_io.Data;
using PGTech_io.Interfaces;

namespace PGTech_io.Models;

public partial class Response : IMessageType
{
    [Key] public int Id { get; set; }
    public string Solutiondescription { get; set; } = null!;
    public DateOnly Createdwhen { get; set; }
    public DateOnly? Updatedwhen { get; set; }
    public string? Iduser { get; set; } // = null!;
    public int Idsender { get; set; }
    public virtual Sender IdsolicitationNavigation { get; set; } = null!;
    public virtual ApplicationUser IduserNavigation { get; set; } = null!;
    
     //------------------------------------------------------------------------------------------------------------------

     public Response()
     {
         Createdwhen = DateOnly.FromDateTime(DateTime.UtcNow);
     }

    //------------------------------------------------------------------------------------------------------------------
    
    public override string ToString()
    {
        return $"{Id} {Idsender}";
    }

    //------------------------------------------------------------------------------------------------------------------
}
