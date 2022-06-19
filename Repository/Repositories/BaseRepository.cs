using Data.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Abstractions;

namespace Repository.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private DbSet<T> entities;

        public BaseRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }

        public IEnumerable<T> GetAll() =>
            entities.AsEnumerable();

        public T GetById(int id) =>
            entities.SingleOrDefault(a => a.Id == id);

        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity not found");
            }

            entities.Add(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity not found");
            }

            entities.Update(entity);
            _applicationDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity not found");
            }

            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }
    }
}
