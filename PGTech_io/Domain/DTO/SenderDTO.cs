using System.Reflection.Metadata;
using PGTech_io.Interfaces;
using PGTech_io.Models;

namespace PGTech_io.DTO;

public class SenderDTO : IMessageType
{
    public int Id { get; set; }
    public string? Iduser { get; set; } 
    public string? UserName { get; set; }
    public string? Client { get; set; }
    public string? Sector { get; set; }
    public string? Subsector { get; set; }
    public string? Problemdescription { get; set; }
    public DateOnly Createdwhen { get; set; }
    public DateOnly? Updatedwhen { get; set; }
    public string? isAnswered { get; set; }
    
    public override string ToString()
    {
        return $"{Id} {UserName} {Client}";
    }
}