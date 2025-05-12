using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace PGTech_io.DTO;

[FirestoreData]
public class UserDTO
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    
}