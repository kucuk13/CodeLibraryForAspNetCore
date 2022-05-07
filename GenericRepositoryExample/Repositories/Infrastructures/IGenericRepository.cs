using GenericRepositoryExample.Models;
using System.Linq.Expressions;

namespace GenericRepositoryExample.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        TEntity Get(int id);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<int> InsertAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> DeleteAsync(int id);
    }
}
