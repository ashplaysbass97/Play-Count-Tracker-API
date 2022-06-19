using Data.Models;
using Repository.Abstractions;
using Service.Abstractions;

namespace Service.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IBaseRepository<Artist> _artistRepository;

        public ArtistService(IBaseRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public IEnumerable<Artist> GetAllArtists()
        {
            return _artistRepository.GetAll();
        }

        public Artist GetArtistById(int id)
        {
            return _artistRepository.GetById(id);
        }

        public void CreateArtist(Artist artist)
        {
            _artistRepository.Create(artist);
        }

        public void UpdateArtist(Artist artist)
        {
            _artistRepository.Update(artist);
        }

        public void DeleteArtistById(int id)
        {
            var artist = _artistRepository.GetById(id);
            _artistRepository.Delete(artist);
        }
    }
}