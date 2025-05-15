using System.Reflection.Metadata;
using PGTech_io.Data;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.DTO;

public class SenderDTO : IMessageType
{
    public int Id { get; set; }
    public string? Iduser { get; set; } 
    public int Idsector { get; set; }
    public int Idsubsector { get; set; }
    public ApplicationUser? IdUserNavigation { get; set; }
    public string? Client { get; set; }
    public Sector? IdsectorNavigation { get; set; }
    public string? Problemdescription { get; set; }
    public DateOnly Createdwhen { get; set; }
    public DateOnly? Updatedwhen { get; set; }
    public string? isAnswered { get; set; }
    
    public override string ToString()
    {
        return $"{IdUserNavigation} {Client} {IdsectorNavigation} {Problemdescription}";
    }
}