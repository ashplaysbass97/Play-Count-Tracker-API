using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Abstractions;

namespace RepositoryLayer.Repositories
{
    public class ArtistRepository<T> : IArtistRepository<T> where T : Artist
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> artists;

        public ArtistRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            artists = _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() =>
            artists.AsEnumerable();

        public T GetById(int id) =>
            artists.SingleOrDefault(a => a.Id == id);

        public void Create(T artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            artists.Add(artist);
            _applicationDbContext.SaveChanges();
        }

        public void Update(T artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            artists.Update(artist);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(T artist)
        {
            if (artist == null)
            {
                throw new ArgumentNullException("artist");
            }

            artists.Remove(artist);
            _applicationDbContext.SaveChanges();
        }
    }
}
