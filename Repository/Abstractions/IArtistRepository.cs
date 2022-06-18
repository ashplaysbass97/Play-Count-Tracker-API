using Data.Models;

namespace Repository.Abstractions
{
    public interface IArtistRepository<T> where T : Artist
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T artist);

        void Update(T artist);

        void Delete(T artist);
    }
}
