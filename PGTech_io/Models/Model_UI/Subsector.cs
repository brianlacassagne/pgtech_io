namespace PGTech_io.Models;

using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

[FirestoreData]
public class Subsector // Admin Defined
{
    [FirestoreProperty] [Key] private int Id { get; set; }
    [FirestoreProperty] private string name { get; set; }
    [FirestoreProperty] private int IdSector { get; set; }
    
    public int ID { get => Id; set => Id = value; }
    public string Name { get => name; set => name = value; }
    public int IDSector { get => IdSector; set => IdSector = value; }
}