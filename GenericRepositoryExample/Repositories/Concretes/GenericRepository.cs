using GenericRepositoryExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryExample.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private Context _context;
        protected DbSet<TEntity> _entity => _context.Set<TEntity>();

        public GenericRepository()
        {
            this._context = new Context();
        }

        public virtual TEntity Get(int id)
        {
            return _entity.Find(id);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetListAsync()
        {
            return await _entity.ToListAsync();
        }

        public virtual async Task<int> InsertAsync(TEntity entity)
        {
            entity.CreatedDateTime = DateTime.Now;
            entity.CreatedMemberId = 1;
            entity.IsDeleted = false;
            await _entity.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDateTime = DateTime.Now;
            entity.UpdatedMemberId = 1;
            entity.IsDeleted = false;
            _entity.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync(int id)
        {
            TEntity entity = await _entity.FindAsync(id);
            if (entity != null)
            {
                entity.DeletedDateTime = DateTime.Now;
                entity.DeletedMemberId = 1;
                entity.IsDeleted = true;
                _entity.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                return await _context.SaveChangesAsync();
            }
            return -1;
        }
    }
}
