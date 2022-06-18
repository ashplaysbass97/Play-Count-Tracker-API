using DomainLayer.Models;

namespace RepositoryLayer.Abstractions
{
    public interface ITrackRepository<T> where T : Track
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T track);

        void Update(T track);

        void Delete(T track);
    }
}
