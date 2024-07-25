using System;
using System.Collections.Generic;

namespace BandList.Models;

public partial class Song
{
    public int SongId { get; set; }

    public string Title { get; set; } = null!;

    public TimeOnly? Duration { get; set; }

    public int? AlbumId { get; set; }

    public virtual Album? Album { get; set; }
}
