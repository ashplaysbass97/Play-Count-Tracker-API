namespace DomainLayer.Models;

public class Track
{
    public int Id { get; set; }
    public int ArtistId { get; set; }
    public Artist Artist { get; set; }
    public string Name { get; set; }
    public int PlayCount { get; set; }
}