using GenericRepositoryExample.Models;

namespace GenericRepositoryExample.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        bool Delete(object id);
        void Save();
    }
}
