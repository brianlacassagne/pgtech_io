using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using PGTech_io.Data;

namespace PGTech_io.DTO;

[FirestoreData]
public class UserDTO : ApplicationUser
{
}