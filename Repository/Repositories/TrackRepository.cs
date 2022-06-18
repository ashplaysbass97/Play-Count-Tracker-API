using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories
{
    public class TrackRepository<T> : ITrackRepository<T> where T : Track
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> tracks;

        public TrackRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            tracks = _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() =>
            tracks.AsEnumerable();

        public T GetById(int id) =>
            tracks.SingleOrDefault(a => a.Id == id);

        public void Create(T track)
        {
            if (track == null)
            {
                throw new ArgumentNullException("track");
            }

            tracks.Add(track);
            _applicationDbContext.SaveChanges();
        }

        public void Update(T track)
        {
            if (track == null)
            {
                throw new ArgumentNullException("track");
            }

            tracks.Update(track);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(T track)
        {
            if (track == null)
            {
                throw new ArgumentNullException("track");
            }

            tracks.Remove(track);
            _applicationDbContext.SaveChanges();
        }
    }
}
