using GenericRepositoryExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryExample.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private Context _context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this._context = new Context();
            table = _context.Set<T>();
        }

        public GenericRepository(Context _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            obj.CreatedDateTime = DateTime.Now;
            table.Add(obj);
        }

        public void Update(T obj)
        {
            obj.UpdatedDateTime = DateTime.Now;
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public bool Delete(object id)
        {
            T existing = table.Find(id);
            if (existing != null)
            {
                existing.DeletedDateTime = DateTime.Now;
                existing.IsDeleted = true;
                _context.Entry(existing).State = EntityState.Modified;
                return true;
            }
            return false;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
