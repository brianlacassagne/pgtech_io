using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace PGTech_io.DTO;

[FirestoreData]
public class UserDTO
{
    [FirestoreProperty] [Key] private int Id { get; set; }
    [FirestoreProperty] private string DisplayName { get; set; }
    [FirestoreProperty] private string Email { get; set; }
    [FirestoreProperty] private string? PhoneNumber { get; set; }

    public int IdProperty
    {
        get => Id;
        set => Id = value;
    }

    public string DisplayNameProperty
    {
        get => DisplayName;
        set => DisplayName = value;
    }

    public string EmailProperty
    {
        get => Email;
        set => Email = value;
    }

    public string? PhoneNumberProperty
    {
        get => PhoneNumber;
        set => PhoneNumber = value;
    }
}