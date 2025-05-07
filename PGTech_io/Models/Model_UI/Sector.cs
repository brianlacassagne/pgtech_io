using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace PGTech_io.Models;

[FirestoreData]
public class Sector // Admin Defined
{
    [FirestoreProperty] [Key] private int Id { get; set; }
    [FirestoreProperty] private string name { get; set; }
    [FirestoreProperty] private bool isVisible { get; set; }
    [FirestoreProperty] private List<int> subsectors { get; set; } // List Id's
    
    public int ID { get => Id; set => Id = value; }
    public string Name { get => name; set => name = value; }
    public bool IsVisible { get => isVisible; set => isVisible = value; }
    public List<int> Subsectors { get => subsectors; set => subsectors = value; }
}