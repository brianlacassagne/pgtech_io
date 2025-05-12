using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PGTech_io.Models;

public partial class Documentation
{
    [Key] public int Id { get; set; }
    public string Filename { get; set; } = null!;
    public string Filetype { get; set; } = null!;
    public string Fileurl { get; set; } = null!;
    public DateOnly Createdwhen { get; set; }
    public int IdSolicitation { get; set; }
    public virtual Sender IdSolicitationNavigation { get; set; } = null!;
    
    //------------------------------------------------------------------------------------------------------------------

    enum TagEnum
    {
        Solicitor = 1,
        Recepiant = 2
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
                Fileurl = value;
            else
                throw new ArgumentNullException(nameof(value), "File URL is null");
        }
    }

    public DateOnly? CreatedWhenProperty
    {
        get => Createdwhen;
        set
        {
            if (value != null)
                Createdwhen = value.Value;
            else
                throw new ArgumentNullException(nameof(value), "Created when is null");
        }
    }

    //------------------------------------------------------------------------------------------------------------------
}
