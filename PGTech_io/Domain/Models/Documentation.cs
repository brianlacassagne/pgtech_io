using System;
using System.Collections.Generic;

namespace PGTech_io.Models;

public partial class Documentation
{
    public int Id { get; set; }

    public string Filename { get; set; } = null!;

    public string Filetype { get; set; } = null!;

    public string Fileurl { get; set; } = null!;

    public DateOnly Createdwhen { get; set; }

    public int Idsolicitation { get; set; }

    public int IdProperty { get; set; }

    public string FileNameProperty { get; set; } = null!;

    public string FileTypeProperty { get; set; } = null!;

    public string FileUrlproperty { get; set; } = null!;

    public DateOnly? CreatedWhenProperty { get; set; }

    public virtual Send IdsolicitationNavigation { get; set; } = null!;
}
