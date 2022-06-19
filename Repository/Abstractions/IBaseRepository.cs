using Data.Models;

namespace Repository.Abstractions
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Create(T artist);

        void Update(T artist);

        void Delete(T artist);
    }
}
