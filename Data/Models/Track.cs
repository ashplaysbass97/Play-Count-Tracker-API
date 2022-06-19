namespace Data.Models;

public class Track : BaseEntity
{
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public int PlayCount { get; set; }
}