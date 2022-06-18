using DomainLayer.Models;

namespace ServiceLayer.Abstractions
{
    public interface IArtistService
    {
        public IEnumerable<Artist> GetAllArtists();

        public Artist GetArtistById(int id);

        public void CreateArtist(Artist artist);

        public void UpdateArtist(Artist artist);

        public void DeleteArtistById(int id);
    }
}
