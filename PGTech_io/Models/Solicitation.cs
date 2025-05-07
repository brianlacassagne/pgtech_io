using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;
using PGTech_io.DTO;
using PGTech_io.Interfaces;

namespace PGTech_io.Models;

[FirestoreData]
public class Solicitation : IMessageType
{
    //-----------------------------------------------------------------------------------------

    public Solicitation()
    {
        CreatedWhen = DateTime.UtcNow;
    }

    public Solicitation(UserDTO _user, string _client, string _sector, string _subsector, string _problemDescription)
    {
        UserId = _user.IdProperty;
        Client = _client;
        Sector = _sector;
        Subsector = _subsector;
        ProblemDescription = _problemDescription;
        CreatedWhen = DateTime.UtcNow;
        UpdatedWhen = null;
        DeletedWhen = null;
    }

    [FirestoreProperty] [Key] private int Id { get; set; }

    [FirestoreProperty] private int UserId { get; set; }
    
    [FirestoreProperty] private int ResponseId { get; set; }

    [FirestoreProperty] private string Client { get; set; }

    [FirestoreProperty] private string ProblemDescription { get; set; }

    [FirestoreProperty] private string Sector { get; set; }

    [FirestoreProperty] private string Subsector { get; set; }

    [FirestoreProperty] private DateTime CreatedWhen { get; set; }

    [FirestoreProperty] private DateTime? DeletedWhen { get; set;}

    [FirestoreProperty] private DateTime? UpdatedWhen { get; set; }

    //-----------------------------------------------------------------------------------------

    public int IdProperty
    {
        get => Id;
        set => Id = value;
    }

    public int IdResponseProperty
    {
        get => ResponseId;
        set => ResponseId = value;
    }

    public int IdUserProperty
    {
        get => UserId;
        set => UserId = value;
    }

    public string ClientProperty
    {
        get => Client;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                Client = value;
            else
                throw new ArgumentNullException(nameof(value), "Client is null");
        }
    }

    public string SectorProperty
    {
        get => Sector;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                Sector = value;
            else
                throw new ArgumentNullException(nameof(value), "Sector is null");
        }
    }

    public string SubsectorProperty
    {
        get => Subsector;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                Subsector = value;
            else
                throw new ArgumentNullException(nameof(value), "Subsector is null");
        }
    }

    public string ProblemDescriptionProperty
    {
        get => ProblemDescription;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException(nameof(value), "Problem description is null");

            if (value.Length > 200)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "Problem description is greater than 200 characters");

            ProblemDescription = value;
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

    public override string ToString()
    {
        return $"{IdProperty} {ClientProperty} {SectorProperty} {SubsectorProperty} {ProblemDescription}";
    }

//-----------------------------------------------------------------------------------------
}