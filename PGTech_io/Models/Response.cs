using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using PGTech_io.DTO;
using PGTech_io.Interfaces;

namespace PGTech_io.Models;

[FirestoreData]
public class Response : IMessageType
{
    [FirestoreProperty] [Key] private int Id { get; set; }
    [FirestoreProperty] private string? ProblemSolution  { get; set; }
    [FirestoreProperty] private int IdUser  { get; set; }
    
    [FirestoreProperty] private int IdSolicitation  { get; set; }
    [FirestoreProperty] private DateTime CreatedWhen { get; set; }
    [FirestoreProperty] private DateTime? DeletedWhen { get; set;}
    [FirestoreProperty] private DateTime? UpdatedWhen { get; set; }

    //------------------------------------------------------------------------------------------------------------------

    public Response() {}
    
    public Response(UserDTO _user, string? _problemSolution)
    {
        IdUser = _user.IdProperty;
        ProblemSolution = _problemSolution;
        CreatedWhen = DateTime.UtcNow;
    }

    //------------------------------------------------------------------------------------------------------------------

    public int IdProperty
    {
        get => Id;
        set => Id = value;
    }

    public int IdSolicitationProperty
    {
        get => IdSolicitation;
        set => IdSolicitation = value;
    }

    public int IdUserProperty
    {
        get => IdUser;
        set => IdUser = value;
    }

    public string? ProblemSolutionProperty
    {
        get => ProblemSolution;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "Problem Solution is null");

            if (value.Length > 200)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Problem Solution is greater than 200 characters");
            
            ProblemSolution = value;
        }
    }
    
    public DateTime CreatedWhenProperty
    {
        get => CreatedWhen;
        set
        {
            if (value != null)
                CreatedWhen = value;
            else
                throw new ArgumentNullException(nameof(value), "Created when is null");
        }
    }

    public DateTime? UpdatedWhenProperty
    {
        get => UpdatedWhen;
        set
        {
            if (value != null)
                UpdatedWhen = value;
            else
                throw new ArgumentNullException(nameof(value), "Updated when is null");
        }
    }

    public DateTime? DeletedWhenProperty
    {
        get => DeletedWhen;
        set
        {
            if (value != null)
                DeletedWhen = value;
            else
                throw new ArgumentNullException(nameof(value), "Deleted when is null");
        }
    }

    //------------------------------------------------------------------------------------------------------------------
}