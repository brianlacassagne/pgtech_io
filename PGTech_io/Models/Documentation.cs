using System.ComponentModel.DataAnnotations;
using Google.Cloud.Firestore;

namespace PGTech_io.Models;

[FirestoreData]
public class Documentation
{
    [FirestoreProperty] [Key] private int Id { get; set; }
    [FirestoreProperty] private string Filename { get; set; }
    [FirestoreProperty] private string Filetype { get; set; }
    [FirestoreProperty] private string FileURL { get; set; } // Firebase requirement
    [FirestoreProperty] private DateTime? UploadedWhen { get; set; }
    [FirestoreProperty] private string? Tag { get; set; }
    [FirestoreProperty] private int IdInteraction { get; set; }
    
    //------------------------------------------------------------------------------------------------------------------

    enum TagEnum
    {
        Solicitor = 1,
        Recepiant = 2
    }

    //------------------------------------------------------------------------------------------------------------------

    public Documentation(string _filename, string _filetype, string _fileUrl, string _tag, DateTime _uploadedWhen)
    {
        Filename = _filename;
        Filetype = _filetype;
        FileURL = _fileUrl;
        UploadedWhen = _uploadedWhen;
        Tag = _tag;
    }

    //------------------------------------------------------------------------------------------------------------------

    public int IdProperty
    {
        get => Id;
        set => Id = value;
    }

    public string FileNameProperty
    {
        get => Filename;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                Filename = value;
            else
                throw new ArgumentNullException(nameof(value), "Filename is null");
        }
    }

    public string FileTypeProperty
    {
        get => Filetype;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                Filetype = value;
            else
                throw new ArgumentNullException(nameof(value), "Filetype is null");
        }
    }

    public string FileURLProperty
    {
        get => Filetype;
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                FileURL = value;
            else
                throw new ArgumentNullException(nameof(value), "File URL is null");
        }
    }

    public DateTime? UploadedWhenProperty
    {
        get => UploadedWhen;
        set
        {
            if (value != null)
                UploadedWhen = value;
            else
                throw new ArgumentNullException(nameof(value), "Uploaded when is null");
        }
    }

    public string? TagProperty
    {
        get => Tag;
        set => Tag = value;
    }

    public int IdInteractionProperty
    {
        get => IdInteraction;
        set => IdInteraction = value;
    }

    //------------------------------------------------------------------------------------------------------------------
}